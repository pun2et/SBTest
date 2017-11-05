using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dell.Adept.UI.Web.Testing.Framework;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Threading;
using SB.Pages;
using SB.Pages.Studio;
using SB.Pages.AdvSummaryPage;
using SB.WorkFlow.WorkFlows;
using System.Data;

using SB.Common;
namespace SB.Tests.AdvisorStudioBVT
{
    [TestClass]
    [SingleWebDriver(false)]
    public class AdvisorBVTTests : SBTestBase
    {
        public AdvisorBVTTests()
        {
           
        }
        #region nonTestcode
        

       

        
        //
        // You can use the following additional attributes as you write your tests:
        //
        [ClassInitialize()]
        public static void TestClassInitialize(TestContext testContext)
        {
            

        }


        [ClassCleanup()]
        public static void TestClassCleanUp()
        {

        }

        [TestInitialize()]
        public void TestInitialize()
        {
            TestWebDriver.Manage().Window.Maximize();
            //TestWebDriver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromMinutes(1));

        }

        [TestCleanup()]
        public void TestCleanup()
        {

        }

            

        [TestMethod]
        [Owner("Jeevitha")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SystemBuilderUIBVT")]
        [Description("883187 TC25:Verify Create quote functionality with EOL product")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\AdvisorBVTData.xml", "SBuilderBVTAmer", DataAccessMethod.Sequential)]
        [DeploymentItem("Data\\GE1\\" + "AdvisorBVTData.xml")]


        public void SBuilderBVTTest_Amer()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).AdvisorBVT(TestContext.DataRow["url"].ToString(),
                                                      TestContext.DataRow["AdvisorTitle"].ToString(),
                                                      TestContext.DataRow["IntroBlurb"].ToString(),
                                                      TestContext.DataRow["Country"].ToString(),
                                                      TestContext.DataRow["checkbox1"].ToString(),
                                                      TestContext.DataRow["checkbox2"].ToString(),
                                                      TestContext.DataRow["Radio"].ToString(),
                                                      TestContext.DataRow["Radio2"].ToString(),
                                                      TestContext.DataRow["Textbox"].ToString(),
                                                      TestContext.DataRow["HiddenQuestionText"].ToString(),
                                                      TestContext.DataRow["NumTextBox"].ToString(),
                                                      TestContext.DataRow["Dropdown"].ToString(),
                                                      TestContext.DataRow["Slider"].ToString(),
                                                      TestContext.DataRow["RangeSlider"].ToString(),
                                                      TestContext.DataRow["Products"].ToString(),
                                                      TestContext.DataRow["SolnName"].ToString()).Equals(true);

        }

        [TestMethod]
        [Owner("Jeevitha")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SystemBuilderUIBVT")]
        [Description("883187 TC25:Verify Create quote functionality with EOL product")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\AdvisorBVTData.xml", "SBuilderBVTEMEA", DataAccessMethod.Sequential)]
        [DeploymentItem("Data\\GE1\\" + "AdvisorBVTData.xml")]


        public void SBuilderBVTTest_EMEA()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).AdvisorBVT(TestContext.DataRow["url"].ToString(),
                                                      TestContext.DataRow["AdvisorTitle"].ToString(),
                                                      TestContext.DataRow["IntroBlurb"].ToString(),
                                                      TestContext.DataRow["Country"].ToString(),
                                                      TestContext.DataRow["checkbox1"].ToString(),
                                                      TestContext.DataRow["checkbox2"].ToString(),
                                                      TestContext.DataRow["Radio"].ToString(),
                                                      TestContext.DataRow["Radio2"].ToString(),
                                                      TestContext.DataRow["Textbox"].ToString(),
                                                      TestContext.DataRow["HiddenQuestionText"].ToString(),
                                                      TestContext.DataRow["NumTextBox"].ToString(),
                                                      TestContext.DataRow["Dropdown"].ToString(),
                                                      TestContext.DataRow["Slider"].ToString(),
                                                      TestContext.DataRow["RangeSlider"].ToString(),
                                                      TestContext.DataRow["Products"].ToString(),
                                                      TestContext.DataRow["SolnName"].ToString()).Equals(true);

        }

        [TestMethod]
        [Owner("Jeevitha")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SystemBuilderUIBVT")]
        [Description("883187 TC25:Verify Create quote functionality with EOL product")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\AdvisorBVTData.xml", "SBuilderBVTAPJ", DataAccessMethod.Sequential)]
        [DeploymentItem("Data\\GE1\\" + "AdvisorBVTData.xml")]


        public void SBuilderBVTTest_APJ()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).AdvisorBVT(TestContext.DataRow["url"].ToString(),
                                                      TestContext.DataRow["AdvisorTitle"].ToString(),
                                                      TestContext.DataRow["IntroBlurb"].ToString(),
                                                      TestContext.DataRow["Country"].ToString(),
                                                      TestContext.DataRow["checkbox1"].ToString(),
                                                      TestContext.DataRow["checkbox2"].ToString(),
                                                      TestContext.DataRow["Radio"].ToString(),
                                                      TestContext.DataRow["Radio2"].ToString(),
                                                      TestContext.DataRow["Textbox"].ToString(),
                                                      TestContext.DataRow["HiddenQuestionText"].ToString(),
                                                      TestContext.DataRow["NumTextBox"].ToString(),
                                                      TestContext.DataRow["Dropdown"].ToString(),
                                                      TestContext.DataRow["Slider"].ToString(),
                                                      TestContext.DataRow["RangeSlider"].ToString(),
                                                      TestContext.DataRow["Products"].ToString(),
                                                      TestContext.DataRow["SolnName"].ToString()).Equals(true);

        }


        #endregion

     
        [TestMethod]
        [Owner("Puneet")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("BVTProd")]
        [Description("Production Advisors Testing")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\AdvisorBVTData.xml", "AdvisorBVTAmer", DataAccessMethod.Sequential)]
        [DeploymentItem("Data\\GE1\\" + "AdvisorBVTData.xml")]

        public void ProTestAMERNEW()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).AdvisorBVTProduction(TestContext.DataRow["url"].ToString(),
                                                      TestContext.DataRow["AdvisorTitle"].ToString(),
                                                      TestContext.DataRow["IntroBlurb"].ToString(),
                                                      TestContext.DataRow["Country"].ToString(),
                                                      TestContext.DataRow["checkbox1"].ToString(),
                                                      TestContext.DataRow["checkbox2"].ToString(),
                                                      TestContext.DataRow["Radio"].ToString(),
                                                      TestContext.DataRow["Radio2"].ToString(),
                                                      TestContext.DataRow["Textbox"].ToString(),
                                                      TestContext.DataRow["HiddenQuestionText"].ToString(),
                                                      TestContext.DataRow["NumTextBox"].ToString(),
                                                      TestContext.DataRow["Dropdown"].ToString(),
                                                      TestContext.DataRow["Slider"].ToString(),
                                                      TestContext.DataRow["RangeSlider"].ToString(),
                                                      TestContext.DataRow["Products"].ToString(),
                                                      TestContext.DataRow["SolnName"].ToString()).Equals(true);

        }

        //[TestMethod]
        //[Owner("Puneet")]
        //[Timeout(TestTimeout.Infinite)]
        //[Priority(1)]
        //[TestCategory("BVTProd")]
        //[Description("Production Advisors Testing")]
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\AdvisorBVTData.xml", "ProTestAMER", DataAccessMethod.Sequential)]
        //[DeploymentItem("Data\\GE1\\" + "AdvisorBVTData.xml")]

        //public void GoogleTesting()
        //{
        //    new AdvisorStudioBVTWorkFlow(TestWebDriver).GoogleTestINProduction(TestContext.DataRow["url"].ToString(),
        //                                              TestContext.DataRow["AdvisorTitle"].ToString(),
        //                                              TestContext.DataRow["IntroBlurb"].ToString(),
        //                                              TestContext.DataRow["Country"].ToString(),
        //                                              TestContext.DataRow["checkbox1"].ToString(),
        //                                              TestContext.DataRow["checkbox2"].ToString(),
        //                                              TestContext.DataRow["Radio"].ToString(),
        //                                              TestContext.DataRow["Radio2"].ToString(),
        //                                              TestContext.DataRow["Textbox"].ToString(),
        //                                              TestContext.DataRow["HiddenQuestionText"].ToString(),
        //                                              TestContext.DataRow["NumTextBox"].ToString(),
        //                                              TestContext.DataRow["Dropdown"].ToString(),
        //                                              TestContext.DataRow["Slider"].ToString(),
        //                                              TestContext.DataRow["RangeSlider"].ToString(),
        //                                              TestContext.DataRow["Products"].ToString(),
        //                                              TestContext.DataRow["SolnName"].ToString()).Equals(true);

        //}


    }
}
