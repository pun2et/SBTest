using System;
using System.Text;
using System.Collections.Generic;
using Common.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using SB.WorkFlow.WorkFlows;
using SB.Common;

namespace SB.Tests.AdvisorServiceBVTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    
    public class AdvisorServiceBVT: ServiceTestBase
    {
        public AdvisorServiceBVT()
        {

            //
            // TODO: Add constructor logic here
            //
        }

       // private TestContext _testContext;
        public TestContext TestContext
        { get
            { return _testContext; }
          set
            { _testContext = value; }
        }

        private static TestContext _testContext;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        [ClassInitialize()]
        public static void TestClassInitialize(TestContext testContext)
        {
            _testContext = testContext;
           
        }

      
        [ClassCleanup()]
        public static void TestClassCleanUp()
        {
          
        }

        [TestInitialize()]
        public  void TestInitialize()
        {
            TestContext = _testContext;
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            
        }



        #endregion

        #region AdvisorOnlineServiceTests

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateExternalServicePing()
        {

            Assert.IsTrue(new ServiceBVTWorkFlow().TestAdvExtServiceAvailibility(_testContext));



        }


        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateAdvExtLoadGivenAdvisor()
        {

            Assert.IsTrue(new ServiceBVTWorkFlow().TestLoadAdvisorStep(_testContext));



        }

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateAdvExtGetRecommended()
        {

            Assert.IsTrue(new ServiceBVTWorkFlow().TestGetRecommendedAdvExt(_testContext));


        }

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateAdvExtIGetCatalogMappedAdvisors()
        {

            Assert.IsTrue(new ServiceBVTWorkFlow().TestIsAdvisorPublishedByMappedAdvisorsAdvExt(_testContext));



        }
        #endregion

        #region AdvisorInternalStudioServiceTests

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateInternalServicePing()
        {
            Assert.IsTrue(new ServiceBVTWorkFlow().TestAdvIntServiceAvailibility(_testContext));            
        }

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateInternalServiceLoadAndTestGivenAdvisor()
        {
            Assert.IsTrue(new ServiceBVTWorkFlow().TestAdvIntServiceLoadAndGetadvisor(_testContext));
            new ServiceBVTWorkFlow();
        
        }

        [TestMethod]
        [Owner("Puneet Pattar")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("SBServiceBVT")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\ServiceTestsData.xml", "AdvisorBVT", DataAccessMethod.Sequential)]
        [DeploymentItem(GlobalVariables.ContentPath + "ServiceTestsData.xml")]
        public void ValidateInternalServiceSaveAndUpdateGivenAdvisor()
        {
            Assert.IsTrue(new ServiceBVTWorkFlow().TestAdvIntServiceSaveAndUpdateadvisor(_testContext));
        }


        #endregion
    }



}


