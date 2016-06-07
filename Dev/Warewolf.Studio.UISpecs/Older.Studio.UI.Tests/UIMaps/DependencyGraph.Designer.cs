﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 11.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

using Dev2.CodedUI.Tests;

namespace Dev2.Studio.UI.Tests.UIMaps.DependencyGraphClasses
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Input;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public partial class DependencyGraph
    {

        /// <summary>
        /// TestAssert - Use 'TestAssertExpectedValues' to pass parameters into this method.
        /// </summary>
        /// <summary>
        /// xd
        /// </summary>
        public void xd()
        {
            #region Variable Declarations
            WpfCustom uIItemCustom = this.UIBusinessDesignStudioWindow.UIItemCustom.UIMyScrollViewerPane.UIItemCustom;
            #endregion

            // Click custom control
            Mouse.Click(uIItemCustom, new Point(478, 388));
        }
        
        #region Properties
        public UIBusinessDesignStudioWindow UIBusinessDesignStudioWindow
        {
            get
            {
                if ((this.mUIBusinessDesignStudioWindow == null))
                {
                    this.mUIBusinessDesignStudioWindow = new UIBusinessDesignStudioWindow();
                }
                return this.mUIBusinessDesignStudioWindow;
            }
        }

        public virtual TestAssertExpectedValues TestAssertExpectedValues
        {
            get
            {
                if ((this.mTestAssertExpectedValues == null))
                {
                    this.mTestAssertExpectedValues = new TestAssertExpectedValues();
                }
                return this.mTestAssertExpectedValues;
            }
        }


        #endregion
        
        #region Fields
        private UIBusinessDesignStudioWindow mUIBusinessDesignStudioWindow;
        private TestAssertExpectedValues mTestAssertExpectedValues;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIBusinessDesignStudioWindow : WpfWindow
    {
        
        public UIBusinessDesignStudioWindow()
        {
            #region Search Criteria
            this.SearchProperties[WpfWindow.PropertyNames.Name] = "Business Design Studio (DEV2\\Jurie.smit)";
            this.SearchProperties.Add(new PropertyExpression(WpfWindow.PropertyNames.ClassName, "HwndWrapper", PropertyExpressionOperator.Contains));
            this.WindowTitles.Add("Business Design Studio (DEV2\\Jurie.smit)");
            #endregion
        }
        
        #region Properties
        public UIItemCustom UIItemCustom
        {
            get
            {
                if ((this.mUIItemCustom == null))
                {
                    this.mUIItemCustom = new UIItemCustom(this);
                }
                return this.mUIItemCustom;
            }
        }
        #endregion
        
        #region Fields
        private UIItemCustom mUIItemCustom;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIItemCustom : WpfCustom
    {
        
        public UIItemCustom(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.DependencyVisualiser";
            this.WindowTitles.Add("Business Design Studio (DEV2\\Jurie.smit)");
            #endregion
        }
        
        #region Properties
        public UIMyScrollViewerPane UIMyScrollViewerPane
        {
            get
            {
                if ((this.mUIMyScrollViewerPane == null))
                {
                    this.mUIMyScrollViewerPane = new UIMyScrollViewerPane(this);
                }
                return this.mUIMyScrollViewerPane;
            }
        }
        #endregion
        
        #region Fields
        private UIMyScrollViewerPane mUIMyScrollViewerPane;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "11.0.50727.1")]
    public class UIMyScrollViewerPane : WpfPane
    {
        
        public UIMyScrollViewerPane(UITestControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[WpfPane.PropertyNames.ClassName] = "Uia.ScrollViewer";
            this.SearchProperties[WpfPane.PropertyNames.AutomationId] = "myScrollViewer";
            this.WindowTitles.Add("Business Design Studio (DEV2\\Jurie.smit)");
            #endregion
        }
        
        #region Properties
        public WpfCustom UIItemCustom
        {
            get
            {
                if ((this.mUIItemCustom == null))
                {
                    this.mUIItemCustom = new WpfCustom(this);
                    #region Search Criteria
                    this.mUIItemCustom.SearchProperties[UITestControl.PropertyNames.ClassName] = "Uia.GraphView";
                    this.mUIItemCustom.WindowTitles.Add("Business Design Studio (DEV2\\Jurie.smit)");
                    #endregion
                }
                return this.mUIItemCustom;
            }
        }

        public WpfText UIRecursiveDependencyTText
        {
            get
            {
                if ((this.mUIRecursiveDependencyTText == null))
                {
                    this.mUIRecursiveDependencyTText = new WpfText(this);
                    #region Search Criteria
                    this.mUIRecursiveDependencyTText.SearchProperties[WpfText.PropertyNames.AutomationId] = "[DependencyGraph_RecursiveDependencyTest_IsCircular_True]";
                    this.mUIRecursiveDependencyTText.WindowTitles.Add(TestBase.GetStudioWindowName());
                    #endregion
                }
                return this.mUIRecursiveDependencyTText;
            }
        }

        #endregion

        
        #region Fields
        private WpfText mUIRecursiveDependencyTText;
        private WpfCustom mUIItemCustom;
        #endregion
    }
}
