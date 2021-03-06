/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2016 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Dev2.Common;
using Dev2.Common.ExtMethods;
using Dev2.Common.Interfaces.Core.Graph;
using Dev2.Data.Util;
using Dev2.Runtime.ServiceModel.Data;
using Newtonsoft.Json;
using Unlimited.Framework.Converters.Graph;
using WarewolfCOMIPC.Client;

namespace Dev2.Runtime.ServiceModel.Esb.Brokers.ComPlugin
{

    /// <summary>
    /// Handler that invokes a plugin in its own app domain
    /// </summary>
    public class ComPluginRuntimeHandler : MarshalByRefObject, IRuntime
    {

        /// <summary>
        /// Runs the specified setup information.
        /// </summary>
        /// <param name="setupInfo">The setup information.</param>
        /// <returns></returns>
        public object Run(ComPluginInvokeArgs setupInfo)
        {
            object pluginResult;
            var methodToRun = ExecuteComPlugin(setupInfo, out pluginResult);
            var formater = setupInfo.OutputFormatter;
            if (formater != null)
            {
                pluginResult = AdjustPluginResult(pluginResult, methodToRun);
                return formater.Format(pluginResult).ToString();
            }
            pluginResult = JsonConvert.SerializeObject(pluginResult);
            return pluginResult;
        }
        public IOutputDescription Test(ComPluginInvokeArgs setupInfo, out string jsonResult)
        {
            try
            {
                jsonResult = null;

                object pluginResult;
                var methodToRun = ExecuteComPlugin(setupInfo, out pluginResult);

                // do formating here to avoid object serialization issues ;)
                var dataBrowser = DataBrowserFactory.CreateDataBrowser();
                var dataSourceShape = DataSourceShapeFactory.CreateDataSourceShape();

                if (pluginResult != null)
                {
                    jsonResult = JsonConvert.SerializeObject(pluginResult);
                    pluginResult = AdjustPluginResult(pluginResult, methodToRun);
                    var tmpData = dataBrowser.Map(pluginResult);
                    dataSourceShape.Paths.AddRange(tmpData);

                }

                var result = OutputDescriptionFactory.CreateOutputDescription(OutputFormats.ShapedXML);
                result.DataSourceShapes.Add(dataSourceShape);
                return result;
            }
            catch (COMException e)
            {
                Dev2Logger.Error("IOutputDescription Test(PluginInvokeArgs setupInfo)", e);
                throw;
            }
            catch (Exception e)
            {
                if(e.InnerException is COMException)
                    throw e.InnerException;
                Dev2Logger.Error("IOutputDescription Test(PluginInvokeArgs setupInfo)", e);
                jsonResult = null;
                return null;
            }

        }

        private MethodInfo ExecuteComPlugin(ComPluginInvokeArgs setupInfo, out object pluginResult)
        {
            var typeList = BuildTypeList(setupInfo.Parameters);
            if (!string.IsNullOrEmpty(setupInfo.ClsId))
            {
                var type = GetType(setupInfo.ClsId, setupInfo.Is32Bit);

                if (type?.Name.ToUpper().Contains("ComObject".ToUpper()) ?? false)
                {
                    using (var client = new Client())
                    {
                        //use Late Binding to Get MethodInfo
                        dynamic objExcel = Activator.CreateInstance(Type.GetTypeFromCLSID(setupInfo.ClsId.ToGuid()));
                        MethodInfo method = ((object)objExcel).GetType().GetMethod(setupInfo.Method);

                        pluginResult = client.Invoke(setupInfo.ClsId.ToGuid(), setupInfo.Method, "ExecuteSpecifiedMethod", new object[] { setupInfo.Parameters });
                        return method;
                    }
                }
                var valuedTypeList = BuildValuedTypeParams(setupInfo);

                if (type != null)
                {
                    var methodToRun = type.GetMethod(setupInfo.Method, typeList.ToArray()) ?? type.GetMethod(setupInfo.Method);
                    if (methodToRun == null && typeList.Count == 0)
                    {
                        methodToRun = type.GetMethod(setupInfo.Method);
                    }
                    var instance = Activator.CreateInstance(type);

                    if (methodToRun != null)
                    {
                        if (methodToRun.ReturnType == typeof(void))
                        {
                            methodToRun.Invoke(instance, BindingFlags.InvokeMethod | BindingFlags.IgnoreCase | BindingFlags.Public, null, valuedTypeList.ToArray(), CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            pluginResult = methodToRun.Invoke(instance, BindingFlags.InvokeMethod | BindingFlags.IgnoreCase | BindingFlags.Public, null, valuedTypeList.ToArray(), CultureInfo.InvariantCulture);
                            return methodToRun;
                        }


                    }
                }
            }
            pluginResult = null;
            return null;
        }

        private static List<object> BuildValuedTypeParams(ComPluginInvokeArgs setupInfo)
        {
            var valuedTypeList = new List<object>();

            foreach(var methodParameter in setupInfo.Parameters)
            {
                try
                {
                    var anonymousType = JsonConvert.DeserializeObject(methodParameter.Value, Type.GetType(methodParameter.TypeName));
                    if(anonymousType != null)
                    {
                        valuedTypeList.Add(anonymousType);
                    }
                }
                catch(Exception)
                {
                    var argType = Type.GetType(methodParameter.TypeName);
                    try
                    {
                        if(argType != null)
                        {
                            var provider = TypeDescriptor.GetConverter(argType);
                            var convertFrom = provider.ConvertFrom(methodParameter.Value);
                            valuedTypeList.Add(convertFrom);
                        }
                    }
                    catch(Exception)
                    {
                        try
                        {
                            var typeConverter = TypeDescriptor.GetConverter(methodParameter.Value);
                            var convertFrom = typeConverter.ConvertFrom(methodParameter.Value);
                            valuedTypeList.Add(convertFrom);
                        }
                        catch(Exception k)
                        {
                            Dev2Logger.Error($"Failed to convert {argType?.FullName}", k);
                        }
                    }
                }
            }
            return valuedTypeList;
        }

        /// <summary>
        /// Lists the namespaces.
        /// </summary>
        /// <param name="classId">The assembly location.</param>
        /// <param name="is32Bit"></param>
        /// <returns></returns>
        private List<string> ListNamespaces(string classId, bool is32Bit)
        {
            try
            {
                var type = GetType(classId, is32Bit);
                var loadedAssembly = type.Assembly;
                // ensure we flush out the rubbish that GAC brings ;)
                var namespaces = loadedAssembly.GetTypes()
                      .Select(t => t.FullName)
                      .Distinct()
                      .Where(q => q.IndexOf("`", StringComparison.Ordinal) < 0
                                  && q.IndexOf("+", StringComparison.Ordinal) < 0
                                  && q.IndexOf("<", StringComparison.Ordinal) < 0
                                  && !q.StartsWith("_")).ToList();

                return namespaces;
            }
            catch (BadImageFormatException e)
            {
                Dev2Logger.Error(e);
                throw;
            }
        }

        private Type GetType(string classId, bool is32Bit)
        {
            Guid clasID;
            Guid.TryParse(classId, out clasID);
            var is64BitProcess = Environment.Is64BitProcess;
            Type type;
            if (is64BitProcess && is32Bit)
            {
                using (var client = new Client())
                {
                    object execute;
                    try
                    {
                        execute = client.Invoke(clasID, "", "GetType", new object[] { });
                        type = execute as Type;
                    }
                    catch (Exception)
                    {

                        type = Type.GetTypeFromCLSID(clasID, true);

                    }


                }
            }
            else
            {
                type = Type.GetTypeFromCLSID(clasID, true);
            }
            return string.IsNullOrEmpty(classId) ? null : type;
        }
        public ServiceMethodList ListMethods(string classId, bool is32Bit)
        {
            var serviceMethodList = new List<ServiceMethod>();
            var orderMethodsLis = new ServiceMethodList();
            classId = classId.Replace("{", "").Replace("}", "");
            var type = GetType(classId, is32Bit);
            if (type?.Name.ToUpper().Contains("ComObject".ToUpper()) ?? false)
            {
                using (var client = new Client())
                {

                    var execute = client.Invoke(classId.ToGuid(), "", "GetMethods", new object[] { });
                    var ipcMethods = execute as List<MethodInfoTO>;
                    if (ipcMethods != null)
                    {

                        foreach (MethodInfoTO ipcMethod in ipcMethods)
                        {
                            var parameterInfos = ipcMethod.Parameters;
                            var serviceMethod = new ServiceMethod { Name = ipcMethod.Name };
                            foreach (var parameterInfo in parameterInfos)
                            {
                                serviceMethod.Parameters.Add(new MethodParameter
                                {
                                    DefaultValue = parameterInfo.DefaultValue?.ToString() ?? string.Empty,
                                    EmptyToNull = false,
                                    IsRequired = true,
                                    Name = parameterInfo.Name,
                                    TypeName = parameterInfo.TypeName
                                });
                              
                            }
                            serviceMethodList.Add(serviceMethod);
                        }

                    }
                    
                    orderMethodsLis.AddRange(serviceMethodList.OrderBy(method => method.Name));
                    return orderMethodsLis;
                }

            }


            if (type == null) return new ServiceMethodList();

            var methodInfos = type.GetMethods();

            methodInfos.ToList().ForEach(info =>
                    {
                        var serviceMethod = new ServiceMethod { Name = info.Name };
                        var parameterInfos = info.GetParameters().ToList();
                        foreach (var parameterInfo in parameterInfos)
                            serviceMethod.Parameters.Add(
                        new MethodParameter
                        {
                            DefaultValue = parameterInfo.DefaultValue?.ToString() ?? string.Empty,
                            EmptyToNull = false,
                            IsRequired = true,
                            Name = parameterInfo.Name,
                            TypeName = parameterInfo.ParameterType.AssemblyQualifiedName
                        });
                        serviceMethodList.Add(serviceMethod);
                    });

            orderMethodsLis.AddRange(serviceMethodList.OrderBy(method => method.Name));
            return orderMethodsLis;
        }

        /// <summary>
        /// Fetches the name space list object.
        /// </summary>
        /// <param name="pluginSource">The plugin source.</param>
        /// <returns></returns>
        public NamespaceList FetchNamespaceListObject(ComPluginSource pluginSource)
        {
            var interrogatePlugin = ReadNamespaces(pluginSource.ClsId, pluginSource.Is32Bit);
            var namespacelist = new NamespaceList { };
            namespacelist.AddRange(interrogatePlugin);
            namespacelist.Add(new NamespaceItem());
            return namespacelist;
        }


        /// <summary>
        /// Adjusts the plugin result.
        /// </summary>
        /// <param name="pluginResult">The plugin result.</param>
        /// <param name="methodToRun">The method automatic run.</param>
        /// <returns></returns>
        private object AdjustPluginResult(object pluginResult, MethodInfo methodToRun)
        {
            object result = pluginResult;
            // When it returns a primitive or string and it is not XML or JSON, make it so ;)
            if ((methodToRun.ReturnType.IsPrimitive || methodToRun.ReturnType.FullName == "System.String")
                && !DataListUtil.IsXml(pluginResult.ToString()) && !DataListUtil.IsJson(pluginResult.ToString()))
            {
                // add our special tags ;)
                result = $"<{GlobalConstants.PrimitiveReturnValueTag}>{pluginResult}</{GlobalConstants.PrimitiveReturnValueTag}>";
            }

            return result;
        }

        /// <summary>
        /// Reads the namespaces.
        /// </summary>
        /// <param name="clsId">The assembly location.</param>
        /// <param name="is32Bit"></param>
        /// <returns></returns>
        private IEnumerable<NamespaceItem> ReadNamespaces(string clsId, bool is32Bit)
        {
            try
            {
                var result = new List<NamespaceItem>();
                var list = ListNamespaces(clsId, is32Bit);
                list.ForEach(fullName =>
                    result.Add(new NamespaceItem
                    {
                        AssemblyLocation = clsId,
                        FullName = fullName,
                        AssemblyName = fullName
                    }));

                return result;
            }
            // ReSharper disable once RedundantCatchClause
            catch (BadImageFormatException)
            {
                throw;
            }
        }

        private Type DeriveType(string typename)
        {
            var type = Type.GetType(typename, true);
            return type;
        }

        /// <summary>
        /// Builds the type list.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns></returns>
        private List<Type> BuildTypeList(IEnumerable<MethodParameter> parameters)
        {
            var typeList = new List<Type>();
            // ReSharper disable once LoopCanBeConvertedToQuery
            foreach (var methodParameter in parameters)
            {
                var type = DeriveType(methodParameter.TypeName);

                typeList.Add(type);
            }
            return typeList;
        }
    }
}
