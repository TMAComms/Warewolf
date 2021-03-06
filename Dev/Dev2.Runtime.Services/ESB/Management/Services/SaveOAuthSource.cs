﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Dev2.Common;
using Dev2.Common.Interfaces;
using Dev2.Common.Interfaces.Core.DynamicServices;
using Dev2.Common.Interfaces.Data;
using Dev2.Common.Interfaces.Infrastructure;
using Dev2.Communication;
using Dev2.Data.ServiceModel;
using Dev2.DynamicServices;
using Dev2.DynamicServices.Objects;
using Dev2.Runtime.Hosting;
using Dev2.Workspaces;

namespace Dev2.Runtime.ESB.Management.Services
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class SaveOAuthSource : IEsbManagementEndpoint
    {
        IExplorerServerResourceRepository _serverExplorerRepository;

        #region Implementation of ISpookyLoadable<out string>

        public string HandlesType()
        {
            return "SaveOAuthSource";
        }

        #endregion

        #region Implementation of IEsbManagementEndpoint

        /// <summary>
        /// Executes the service
        /// </summary>
        /// <param name="values">The values.</param>
        /// <param name="theWorkspace">The workspace.</param>
        /// <returns></returns>
        public StringBuilder Execute(Dictionary<string, StringBuilder> values, IWorkspace theWorkspace)
        {
            ExecuteMessage msg = new ExecuteMessage();
            Dev2JsonSerializer serializer = new Dev2JsonSerializer();
            try
            {
                Dev2Logger.Info("Save OAuth Source");
                StringBuilder resourceDefinition;

                values.TryGetValue("OAuthSource", out resourceDefinition);

                var src = serializer.Deserialize<IOAuthSource>(resourceDefinition);
                if (src.ResourcePath.EndsWith("\\"))
                    src.ResourcePath = src.ResourcePath.Substring(0, src.ResourcePath.LastIndexOf("\\", StringComparison.Ordinal));

                IResource res = null;

                switch (src.GetType().Name)
                {
                    case "DropBoxSource":
                        res = new DropBoxSource()
                        {
                            ResourceID = src.ResourceID,
                            AppKey = src.AppKey,
                            AccessToken = src.AccessToken,
                            ResourceName = src.ResourceName,
                            ResourcePath = src.ResourcePath
                        };
                        break;
                }

                ResourceCatalog.Instance.SaveResource(GlobalConstants.ServerWorkspaceID, res);
                ServerExplorerRepo.UpdateItem(res);
                msg.HasError = false;

            }
            catch (Exception err)
            {
                msg.HasError = true;
                msg.Message = new StringBuilder(err.Message);
                Dev2Logger.Error(err);

            }

            return serializer.SerializeToBuilder(msg);
        }

        public IExplorerServerResourceRepository ServerExplorerRepo
        {
            get { return _serverExplorerRepository ?? ServerExplorerRepository.Instance; }
            set { _serverExplorerRepository = value; }
        }

        /// <summary>
        /// Creates the service entry.
        /// </summary>
        /// <returns></returns>
        public DynamicService CreateServiceEntry()
        {
            DynamicService newDs = new DynamicService { Name = HandlesType(), DataListSpecification = new StringBuilder("<DataList><Roles ColumnIODirection=\"Input\"/><PluginSource ColumnIODirection=\"Input\"/><WorkspaceID ColumnIODirection=\"Input\"/><Dev2System.ManagmentServicePayload ColumnIODirection=\"Both\"></Dev2System.ManagmentServicePayload></DataList>") };
            ServiceAction sa = new ServiceAction { Name = HandlesType(), ActionType = enActionType.InvokeManagementDynamicService, SourceMethod = HandlesType() };
            newDs.Actions.Add(sa);

            return newDs;
        }

        #endregion
    }
}
