// ***********************************************************************
// Author           : AMERICAS\Puneet_Pattar
// Created          : 3/15/2017 7:51:51 PM
//
// Last Modified By : AMERICAS\Puneet_Pattar
// Last Modified On : 3/15/2017 7:51:51 PM
// ***********************************************************************
// <copyright file="SBTestBase.cs" company="Dell">
//     Copyright (c) Dell 2017. All rights reserved.
// </copyright>
// <summary>Describe what is being tested in this test class here.</summary>
// ***********************************************************************
using System;
using System.Configuration;
using System.Threading;
using Dell.Adept.UI.Web.Testing.Framework;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using SS.Utils;
using System.Drawing;
using System.Drawing.Imaging;

namespace Common.Base
{
    /// <summary>
    /// Summary description for SBTestBase
    /// </summary>
    [TestClass]
    [SingleWebDriver(false)]
    //[DeploymentItem("chromedriver.exe")]
    //[DeploymentItem("IEDriverServer.exe")]
    public class SBTestBase : WebUIMsTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SBTestBase"/> class.
        /// </summary>
        private EventFiringWebDriver firingDriver;
        private SS.Utils.FeedbackDialog feedback;


        [TestInitialize]
        public void SBTestBaseBaseInitialize()
        {
            //base.BaseTestInitialize();

            var browserClosed = "Unable to connect to the remote server";
            try
            {
                if (TestWebDriver.WindowHandles.Count == 1)
                {
                   var localWebDriver = new ChromeDriver(@"C:\Program Files (x86)\AdeptSDK\",new ChromeOptions(), TimeSpan.FromMinutes(4));
                    TestWebDriver = localWebDriver;
                    //base.InitializeWebDriver();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains(browserClosed))
                {
                    base.InitializeWebDriver();
                }
            }

            firingDriver = new EventFiringWebDriver(TestWebDriver);
            feedback = new FeedbackDialog(TestWebDriver);
            TestWebDriver = firingDriver;


            firingDriver.ExceptionThrown += firingDriver_ExceptionThrown;
            firingDriver.Navigated += firingDriver_Navigated;
            firingDriver.ElementClicking += firingDriver_ElementClicking;


        }
            void firingDriver_ElementClicking(object sender, WebElementEventArgs e)


            {
                feedback.CloseFeedBack();
            }

        void firingDriver_Navigated(object sender, WebDriverNavigationEventArgs e)
        {
            feedback.CloseFeedBack();
        }

        void firingDriver_ExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            if (feedback.IsDialogExist())
            {
                feedback.CloseFeedBack();
            }
            else
            {
                

                Screenshot Currentscreen = ((ITakesScreenshot)firingDriver).GetScreenshot();
                string screenshot = Currentscreen.AsBase64EncodedString;
                byte[] screenshotAsByteArray = Currentscreen.AsByteArray;
                Currentscreen.SaveAsFile("filename", ImageFormat.Png);
                //throw e.ThrownException;
            }
        }
        }
    }


