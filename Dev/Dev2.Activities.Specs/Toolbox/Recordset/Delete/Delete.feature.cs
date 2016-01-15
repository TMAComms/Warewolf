﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Dev2.Activities.Specs.Toolbox.Recordset.Delete
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class DeleteFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "Delete.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Delete", "In order to delete records\r\nAs a Warewolf user\r\nI want a tool that takes a record" +
                    " set and deletes it", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "Delete")))
            {
                Dev2.Activities.Specs.Toolbox.Recordset.Delete.DeleteFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete last record in a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteLastRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete last record in a recordset", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table1.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 7
 testRunner.Given("I have the following recordset", ((string)(null)), table1, "Given ");
#line 12
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 13
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 14
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table2.AddRow(new string[] {
                        "rs().row",
                        "2"});
#line 15
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table2, "And ");
#line 19
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table3.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 20
 testRunner.And("the debug inputs as", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table4.AddRow(new string[] {
                        "[[result]] = Success"});
#line 23
 testRunner.And("the debug output as", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table5.AddRow(new string[] {
                        "[[result]] = Success"});
#line 26
 testRunner.And("the debug output as", ((string)(null)), table5, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete an invalid recordset (recordset with no fields declared)")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteAnInvalidRecordsetRecordsetWithNoFieldsDeclared()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete an invalid recordset (recordset with no fields declared)", ((string[])(null)));
#line 30
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table6.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 31
 testRunner.Given("I have the following recordset", ((string)(null)), table6, "Given ");
#line 36
 testRunner.And("I delete a record \"[[GG()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 37
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 39
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table7.AddRow(new string[] {
                        "[[GG()]] ="});
#line 40
 testRunner.And("the debug inputs as", ((string)(null)), table7, "And ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table8.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 43
 testRunner.And("the debug output as", ((string)(null)), table8, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete the first record in a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteTheFirstRecordInARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete the first record in a recordset", ((string[])(null)));
#line 47
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table9.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 48
 testRunner.Given("I have the following recordset", ((string)(null)), table9, "Given ");
#line 53
 testRunner.And("I delete a record \"[[rs(1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 54
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 55
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table10.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 56
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table10, "And ");
#line 60
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table11.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
#line 61
 testRunner.And("the debug inputs as", ((string)(null)), table11, "And ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table12.AddRow(new string[] {
                        "[[result]] = Success"});
#line 64
 testRunner.And("the debug output as", ((string)(null)), table12, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using an index from a variable")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingAnIndexFromAVariable()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using an index from a variable", ((string[])(null)));
#line 68
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "6"});
            table13.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 69
 testRunner.Given("I have the following recordset", ((string)(null)), table13, "Given ");
#line 74
 testRunner.And("an index \"[[index]]\" exists with a value \"2\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 75
 testRunner.And("I delete a record \"[[rs([[index]])]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 76
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 77
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table14.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 78
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table14, "And ");
#line 82
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table15 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table15.AddRow(new string[] {
                        "[[rs(2).row]] = 6"});
#line 83
 testRunner.And("the debug inputs as", ((string)(null)), table15, "And ");
#line hidden
            TechTalk.SpecFlow.Table table16 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table16.AddRow(new string[] {
                        "[[result]] = Success"});
#line 86
 testRunner.And("the debug output as", ((string)(null)), table16, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using a star notation")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingAStarNotation()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a star notation", ((string[])(null)));
#line 90
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table17 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table17.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table17.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table17.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 91
 testRunner.Given("I have the following recordset", ((string)(null)), table17, "Given ");
#line 96
 testRunner.And("I delete a record \"[[rs(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 97
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 98
 testRunner.Then("the delete result should be \"Success\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table18 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
#line 99
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table18, "And ");
#line 101
 testRunner.And("the execution has \"NO\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table19 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table19.AddRow(new string[] {
                        "[[rs(1).row]] = 1"});
            table19.AddRow(new string[] {
                        "[[rs(2).row]] = 2"});
            table19.AddRow(new string[] {
                        "[[rs(3).row]] = 3"});
#line 102
 testRunner.And("the debug inputs as", ((string)(null)), table19, "And ");
#line hidden
            TechTalk.SpecFlow.Table table20 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table20.AddRow(new string[] {
                        "[[result]] = Success"});
#line 107
 testRunner.And("the debug output as", ((string)(null)), table20, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record using a negative integer -1")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordUsingANegativeInteger_1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record using a negative integer -1", ((string[])(null)));
#line 111
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table21 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table21.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 112
 testRunner.Given("I have the following recordset", ((string)(null)), table21, "Given ");
#line 117
 testRunner.And("I delete a record \"[[rs(-1)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 118
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 119
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table22 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table22.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table22.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table22.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 120
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table22, "And ");
#line 125
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table23 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table23.AddRow(new string[] {
                        "[[rs(-1)]]  ="});
#line 126
 testRunner.And("the debug inputs as", ((string)(null)), table23, "And ");
#line hidden
            TechTalk.SpecFlow.Table table24 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table24.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 129
 testRunner.And("the debug output as", ((string)(null)), table24, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record that does not exist")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordThatDoesNotExist()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record that does not exist", ((string[])(null)));
#line 133
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table25 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table25.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 134
 testRunner.Given("I have the following recordset", ((string)(null)), table25, "Given ");
#line 139
 testRunner.And("I delete a record \"[[rs(5)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 140
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 141
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table26 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table26.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table26.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table26.AddRow(new string[] {
                        "rs().row",
                        "3"});
#line 142
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table26, "And ");
#line 147
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table27 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table27.AddRow(new string[] {
                        "[[rs(5)]]  ="});
#line 148
 testRunner.And("the debug inputs as", ((string)(null)), table27, "And ");
#line hidden
            TechTalk.SpecFlow.Table table28 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table28.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 151
 testRunner.And("the debug output as", ((string)(null)), table28, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a record an empty recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteARecordAnEmptyRecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a record an empty recordset", ((string[])(null)));
#line 155
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table29 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
#line 156
 testRunner.Given("I have the following recordset", ((string)(null)), table29, "Given ");
#line 158
 testRunner.And("I delete a record \"[[rs()]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 159
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 160
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 161
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table30 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
            table30.AddRow(new string[] {
                        "[[rs()]]  ="});
#line 162
 testRunner.And("the debug inputs as", ((string)(null)), table30, "And ");
#line hidden
            TechTalk.SpecFlow.Table table31 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table31.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 165
 testRunner.And("the debug output as", ((string)(null)), table31, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete a scalar insted of a recordset")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteAScalarInstedOfARecordset()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete a scalar insted of a recordset", ((string[])(null)));
#line 169
this.ScenarioSetup(scenarioInfo);
#line 170
 testRunner.Given("I have a delete variable \"[[var]]\" equal to \"\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 171
 testRunner.And("I delete a record \"[[var]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 172
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 173
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 174
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table32 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 175
 testRunner.And("the debug inputs as", ((string)(null)), table32, "And ");
#line hidden
            TechTalk.SpecFlow.Table table33 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table33.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 177
 testRunner.And("the debug output as", ((string)(null)), table33, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete two recordset data.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteTwoRecordsetData_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete two recordset data.", ((string[])(null)));
#line 181
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table34 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table34.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table34.AddRow(new string[] {
                        "ws().row",
                        "3"});
            table34.AddRow(new string[] {
                        "ws().row",
                        "4"});
#line 182
 testRunner.Given("I have the following recordset", ((string)(null)), table34, "Given ");
#line 188
 testRunner.And("I delete a record \"[[rs(*)]],[[ws(*)]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 189
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 190
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table35 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table35.AddRow(new string[] {
                        "[[rs(1).row]]",
                        "1"});
            table35.AddRow(new string[] {
                        "[[rs(1).row]]",
                        "2"});
#line 191
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table35, "And ");
#line hidden
            TechTalk.SpecFlow.Table table36 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table36.AddRow(new string[] {
                        "[[ws(1).row]]",
                        "3"});
            table36.AddRow(new string[] {
                        "[[ws(2).row]]",
                        "4"});
#line 195
 testRunner.And("the recordset \"[[ws(*).row]]\" will be as follows", ((string)(null)), table36, "And ");
#line 199
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table37 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 200
 testRunner.And("the debug inputs as", ((string)(null)), table37, "And ");
#line hidden
            TechTalk.SpecFlow.Table table38 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table38.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 202
 testRunner.And("the debug output as", ((string)(null)), table38, "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("Delete two specific recordset data.")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "Delete")]
        public virtual void DeleteTwoSpecificRecordsetData_()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Delete two specific recordset data.", ((string[])(null)));
#line 206
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table39 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "val"});
            table39.AddRow(new string[] {
                        "rs().row",
                        "1"});
            table39.AddRow(new string[] {
                        "rs().row",
                        "2"});
            table39.AddRow(new string[] {
                        "rs().row",
                        "3"});
            table39.AddRow(new string[] {
                        "rs().row",
                        "4"});
#line 207
 testRunner.Given("I have the following recordset", ((string)(null)), table39, "Given ");
#line 213
 testRunner.And("I delete a record \"[[rs(1).a]],[[rs(4).a]]\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 214
 testRunner.When("the delete tool is executed", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 215
 testRunner.Then("the delete result should be \"Failure\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            TechTalk.SpecFlow.Table table40 = new TechTalk.SpecFlow.Table(new string[] {
                        "rs",
                        "row"});
            table40.AddRow(new string[] {
                        "[[rs().row]]",
                        "1"});
            table40.AddRow(new string[] {
                        "[[rs().row]]",
                        "2"});
            table40.AddRow(new string[] {
                        "[[rs().row]]",
                        "3"});
            table40.AddRow(new string[] {
                        "[[rs().row]]",
                        "4"});
#line 216
 testRunner.And("the recordset \"[[rs(*).row]]\" will be as follows", ((string)(null)), table40, "And ");
#line 222
 testRunner.And("the execution has \"AN\" error", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            TechTalk.SpecFlow.Table table41 = new TechTalk.SpecFlow.Table(new string[] {
                        "Records"});
#line 223
 testRunner.And("the debug inputs as", ((string)(null)), table41, "And ");
#line hidden
            TechTalk.SpecFlow.Table table42 = new TechTalk.SpecFlow.Table(new string[] {
                        ""});
            table42.AddRow(new string[] {
                        "[[result]] = Failure"});
#line 225
 testRunner.And("the debug output as", ((string)(null)), table42, "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
