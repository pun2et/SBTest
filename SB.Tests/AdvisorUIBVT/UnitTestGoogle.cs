using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Base;
using SB.WorkFlow.WorkFlows;

namespace SB.Tests.AdvisorUIBVT
{
    /// <summary>
    /// Summary description for UnitTestGoogle
    /// </summary>
    [TestClass]
    public class UnitTestGoogle: SBTestBase
    {
        public UnitTestGoogle()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        [Owner("Puneet")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("Google")]
        [Description("GoogleTest")]
        public void TestMethod1()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).GoogleTestINProduction().Equals(true);
        }

        [TestMethod]
        [Owner("Puneet")]
        [Timeout(TestTimeout.Infinite)]
        [Priority(1)]
        [TestCategory("Google")]
        [Description("GoogleTest2")]
        public void TestMethod2()
        {
            new AdvisorStudioBVTWorkFlow(TestWebDriver).GoogleTestINProduction().Equals(true);
        }
    }
}
