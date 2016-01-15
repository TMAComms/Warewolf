
/*
*  Warewolf - The Easy Service Bus
*  Copyright 2014 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later. 
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/


// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using Dev2.Studio.UI.Tests.Utils;

namespace Dev2.CodedUI.Tests.UIMaps.DeployViewUIMapClasses
{
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using System.CodeDom.Compiler;


    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class DeployViewUIMap
    {
        private UITestControl DestinationServerTreeviewExplorer(UITestControl theTab)
        {
            UITestControlCollection allChildren = DeployTabsChildren(theTab);
            UITestControl targetNavigationView = new UITestControl();
            foreach(UITestControl theControl in allChildren)
            {
                if(theControl.GetProperty("AutomationId").ToString() == "TargetNavigationView")
                {
                    targetNavigationView = theControl;
                    break;
                }
            }

            return targetNavigationView.GetChildren()[0];
        }

        private UITestControlCollection DeployTabsChildren(UITestControl theTab)
        {
            return GetDeployUserControlChildren(theTab);
        }

        public UITestControl GetSourceServerList(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                if(theControl.GetProperty("AutomationId").ToString() == "ConnectUserControl")
                {
                    foreach(UITestControl tC in theControl.GetChildren())
                    {
                        if(tC.GetProperty("AutomationId").ToString() == "UI_SourceServercbx_AutoID")
                        {
                            return tC;

                        }
                    }

                }
            }
            return null;
        }

        public UITestControl GetSourceEditConnectionButton(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                if(theControl.GetProperty("AutomationId").ToString() == "ConnectUserControl")
                {
                    foreach(UITestControl tC in theControl.GetChildren())
                    {
                        if(tC.GetProperty("AutomationId").ToString() == "UI_SourceServerEditbtn_AutoID")
                        {
                            return tC;

                        }
                    }

                }
            }
            return null;
        }

        private WpfEdit GetSourceServerFilterBox(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                var autoID = theControl.GetProperty("AutomationId").ToString();
                if(autoID == "SourceNavigationView")
                {
                    foreach(var child in theControl.GetChildren())
                    {
                        var childAutoID = child.GetProperty("AutomationId").ToString();
                        if(childAutoID == "FilterTextBox")
                        {
                            var sourceServerFilterBox = (WpfEdit)theControl.GetChildren()[0];
                            return sourceServerFilterBox;
                        }
                    }
                }
            }

            return null;
        }

        private WpfEdit GetDestinationServerFilterBox(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                var autoID = theControl.GetProperty("AutomationId").ToString();
                if(autoID == "TargetNavigationView")
                {
                    foreach(var child in theControl.GetChildren())
                    {
                        var childAutoID = child.GetProperty("AutomationId").ToString();
                        if(childAutoID == "FilterTextBox")
                        {
                            return (WpfEdit)theControl.GetChildren()[0];
                        }
                    }
                }
            }

            return null;
        }

        public UITestControl GetDestinationServerList(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                if(theControl.GetProperty("AutomationId").ToString() == "ConnectUserControl")
                {
                    foreach(UITestControl tC in theControl.GetChildren())
                    {
                        if(tC.GetProperty("AutomationId").ToString() == "UI_DestinationServercbx_AutoID")
                        {
                            return tC;

                        }
                    }

                }
            }
            return null;
        }

        private int GetSelectedDeployCount(UITestControl theTab)
        {
            int totalCount = 0;
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            for(int j = 0; j < requiredChildren.Count; j++)
            {
                UITestControl theControl = requiredChildren[j];
                if(theControl.GetProperty("Name") != null)
                {
                    string nameProperty = theControl.GetProperty("Name").ToString();
                    if((nameProperty == "Services  : ") || (nameProperty == "Workflows  : ") || (nameProperty == "Sources  : "))
                    {
                        WpfText textControl = (WpfText)requiredChildren[j + 1];

                        int count = int.Parse(textControl.DisplayText);
                        totalCount += count;
                    }
                }
            }
            return totalCount;
        }

        private int GetSelectedDeploySummaryCount(UITestControl theTab)
        {
            int totalCount = 0;
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            for(int j = 0; j < requiredChildren.Count; j++)
            {
                UITestControl theControl = requiredChildren[j];
                if(theControl.GetProperty("Name") != null)
                {
                    string nameProperty = theControl.GetProperty("Name").ToString();
                    if((nameProperty == "New Resources  : ") || (nameProperty == "Override  : "))
                    {
                        WpfText textControl = (WpfText)requiredChildren[j + 1];

                        int count = int.Parse(textControl.DisplayText);
                        totalCount += count;
                    }
                }
            }
            return totalCount;
        }

        private UITestControlCollection GetDeployUserControlChildren(UITestControl theTab)
        {



            return VisualTreeWalker.GetChildByAutomationIdPath(theTab, "WorkSurfaceContextViewModel", "DeployUserControl").GetChildren();

        }

        private UITestControl GetDeployUserControl(UITestControl theTab)
        {


            return VisualTreeWalker.GetChildByAutomationIdPath(theTab, "WorkSurfaceContextViewModel", "DeployUserControl");

        }

        private WpfButton GetDeployButton(UITestControl theTab)
        {
            UITestControlCollection requiredChildren = GetDeployUserControlChildren(theTab);
            foreach(UITestControl theControl in requiredChildren)
            {
                if(theControl.GetProperty("AutomationId") != null)
                {
                    if(theControl.GetProperty("AutomationId").ToString() == "UI_Deploybtn_AutoID")
                    {
                        return (WpfButton)theControl;
                    }
                }
            }
            return null;
        }
    }
}
