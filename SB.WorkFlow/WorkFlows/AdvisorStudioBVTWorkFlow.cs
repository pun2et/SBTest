using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB.Pages;
using SB.Pages.Studio;
using OpenQA.Selenium.Interactions;
using System.Threading;

using OpenQA.Selenium.Chrome;
using SB.Pages.AdvSummaryPage;
using OpenQA.Selenium.Chrome;
using System.Drawing.Imaging;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;

namespace SB.WorkFlow.WorkFlows
{
  public class AdvisorStudioBVTWorkFlow
    {
        IWebDriver webDriver;
        static bool isValidationPassed = true;
        static bool isFirstTimeValidationSet;

        public static bool IsValidationPassed
        {
            get
            {
                return isValidationPassed;
            }

            set
            {
                if (value == false)
                {

                }
                // if once validation failed we are no more going pass test case.
                if (isValidationPassed || isFirstTimeValidationSet)
                {
                    isValidationPassed = value;
                    isFirstTimeValidationSet = false;

                }
            }
        }

        public AdvisorStudioBVTWorkFlow(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public void Log(string logString)
        {
            //log4net.Config.BasicConfigurator.Configure();
            //var log = log4net.LogManager.GetLogger(typeof(CPQWorkFlow));
            //log.Info(logString);
        }

        public bool AdvisorBVT(string url, string AdvisorTitle,string IntroBlurb, string Country, string checkbox1, string checkbox2, string Radio,string Radio2, string Textbox,string hiddenQtext, string NumTextBox, string Dropdown, string Slider, string RangeSlider, string Products, string SolnName)
           {
            bool isValidationPassed = true;
            AdvisorStudioBVTWorkFlow Advisorbvt = new AdvisorStudioBVTWorkFlow(webDriver);
            AdvisorSteps Advsrsteps = new AdvisorSteps(webDriver);
            AdvisorSummaryPage Advsrsummary = new AdvisorSummaryPage(webDriver);
            StartAdvisorPage AdvsrstartPage = new StartAdvisorPage(webDriver);

            Screenshot Currentscreen0 = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot0 = Currentscreen0.AsBase64EncodedString;
            byte[] screenshotAsByteArray0 = Currentscreen0.AsByteArray;
            Currentscreen0.SaveAsFile("filename0.jpg", ImageFormat.Png);

            webDriver.Navigate().GoToUrl(url);
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            //Log()
            IsValidationPassed = isValidationPassed = AdvsrstartPage.verifySBTitle(AdvisorTitle);
            //Log(string.Format("Sb Ttile   = {0}", isValidation));
            //Log
            IsValidationPassed = AdvsrstartPage.verifyIntroBlurb(IntroBlurb);
            //Result
            AdvsrstartPage.SelectCountry(Country);
            
            Screenshot Currentscreen = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot = Currentscreen.AsBase64EncodedString;
            byte[] screenshotAsByteArray = Currentscreen.AsByteArray;
            Currentscreen.SaveAsFile("filename1.jpg", ImageFormat.Png);
            System.IO.File.WriteAllLines("currentURL.txt", new string[] { webDriver.Url.ToString() } );
            Thread.Sleep(20000);
            //AdvsrstartPage.ClickStartAdvisorBtn();

           var isenabledValue =  webDriver.FindElement(By.XPath("//*[@id='btnPrimary']/span")).Enabled;
            System.IO.File.WriteAllText("currentURLisenabledValue.txt", isenabledValue.ToString());
            Thread.Sleep(20000);

            webDriver.FindElement(By.XPath("//*[@id='btnPrimary']/span")).Click();
            Thread.Sleep(20000);
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            string[] param = null;
            List<string[]> Comps = new List<string[]>();
            Actions a = new Actions(webDriver);

            Screenshot Currentscreen1 = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot1 = Currentscreen.AsBase64EncodedString;
            byte[] screenshotAsByteArray1 = Currentscreen.AsByteArray;
            Currentscreen.SaveAsFile("filename2.jpg", ImageFormat.Png);
            System.IO.File.WriteAllLines("currentURL1.txt", new string[] { webDriver.Url.ToString() });
            //STEP1
            IsValidationPassed = isValidationPassed = Advsrsteps.Gettooltip(a).Contains("Step 1");
            // Check First Answer- First Question
            param = Advsrsteps.QnA(checkbox1);
            Comps.Add(param);
            IsValidationPassed = isValidationPassed = Advsrsteps.selectCheckbox(param[0], param[1]);
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            //STEP2
            // Verify Second Answer Disabled
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            param = Advsrsteps.QnA(Radio2);
            IsValidationPassed = isValidationPassed = Advsrsteps.verifyRadioButtondisabled(param[0], param[1]).Equals(false);
            Thread.Sleep(5000);
            //Log(string.Format("Is checkbox selected  = {0}", isValidation));
            Advsrsteps.ClickPrevBtn();
            Thread.Sleep(5000);
            //STEP1
            param = Advsrsteps.QnA(checkbox2);
            Comps.Add(param);
            IsValidationPassed = isValidationPassed = Advsrsteps.selectCheckbox(param[0], param[1]);

            //Log(string.Format("Is checkbox selected  = {0}", isValidation));
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            param = Advsrsteps.QnA(Radio2);
            IsValidationPassed = isValidationPassed = Advsrsteps.verifyRadioButtondisabled(param[0], param[1]);
            //STEP3
            new AdvisorSteps(webDriver).ClickStepNumber("3");
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            IsValidationPassed = isValidationPassed = Advsrsteps.IsQuestionhidden(hiddenQtext).Equals(false);
            Advsrsteps.ClickPrevBtn();
            Thread.Sleep(5000);
            // STEP2
            IsValidationPassed = isValidationPassed = Advsrsteps.Gettooltip(a).Contains("Step 2");
            param = Advsrsteps.QnA(Radio);
            Comps.Add(param);
            IsValidationPassed = isValidationPassed = Advsrsteps.selectRadioButton(param[0], param[1]);
            //Advsrsteps.ClickPrevBtn();
            Thread.Sleep(5000);
            param = Advsrsteps.QnA(Radio2);
            IsValidationPassed = isValidationPassed = Advsrsteps.verifyRadioButtondisabled(param[0], param[1]);
            //webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            new AdvisorSteps(webDriver).ClickStepNumber("3");
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //STEP3
            IsValidationPassed = isValidationPassed = Advsrsteps.Gettooltip(a).Contains("Step 3");
            param = Advsrsteps.QnA(Textbox);
            Comps.Add(param);
            Advsrsteps.Textbox(param[0], param[1], param[2]);
            Thread.Sleep(5000);
            IsValidationPassed = isValidationPassed = Advsrsteps.IsQuestionhidden(hiddenQtext);
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //STEP4
            param = Advsrsteps.QnA(NumTextBox);
            Comps.Add(param);
            Advsrsteps.Textbox(param[0], param[1], param[2]);
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //STEP5
            param = Advsrsteps.QnA(Dropdown);
            Comps.Add(param);
            IsValidationPassed = isValidationPassed = Advsrsteps.DropDown(param[0], param[1]);
            Thread.Sleep(2000);
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            //STEP6
            param = Advsrsteps.QnA(Slider);
            Comps.Add(param);
            Advsrsteps.Slider(param[0], int.Parse(param[1]));
            Thread.Sleep(1000);
            // webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Advsrsteps.ClickNextBtn();
            Thread.Sleep(5000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(30));
            Thread.Sleep(2000);
            //STEP7
            param = Advsrsteps.QnA(RangeSlider);
            //Comps.Add(param);-- requires fix
            Advsrsteps.RangeSlider(param[0], int.Parse(param[1]), int.Parse(param[2]));
            Thread.Sleep(2000);
            Advsrsteps.ClickNextBtn();
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            //Log("Verifying Review summary tooltip");
            Thread.Sleep(15000);
            //STEP8
            IsValidationPassed = isValidationPassed = Advsrsteps.Gettooltip(a).Contains("Review Summary");
            ////Log(string.Format("Review Summary ToolTip   = {0}", isValidation));
           // IsValidationPassed = isValidationPassed = Advsrsummary.VerifyInputSummary(Comps);
            ////Log(string.Format("Input Summary validation  = {0}", isValidation));

            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            Advsrsteps.ClickGetRecommendation();
            Thread.Sleep(20000);
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            string sol = new AdvisorSummaryPage(webDriver).GetSolnId();
            IsValidationPassed = isValidationPassed = !string.IsNullOrEmpty(sol);
            //Log(string.Format("Verifying Solution ID:{0}",isValidationPassed);
            //Log(string.Format("Generated Solution ID:{0}", new AdvisorSummaryPage(webDriver).GetSolnId()));
            IsValidationPassed = isValidationPassed = Advsrsummary.VerifySolnName(SolnName);
            //Log(string.Format("Verifying Solution Name:{0}",isValidationPassed);
            IsValidationPassed = isValidationPassed = Advsrsummary.IsPdfLnkDisplayed();
            //Advsrsummary.PdfDownload();
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
            //Log(string.Format("Verifying Pdf Link:{0}",isValidationPassed);
            IsValidationPassed = isValidationPassed = Advsrsummary.IsstartOverLnkDisplayed();
            //Log(string.Format("Verifying StartOver Link:{0}",isValidationPassed);
            IsValidationPassed = isValidationPassed = Advsrsummary.VerifyProducts(Products);
            //Log(string.Format("Verifying Solution Products:{0}",isValidationPassed);
            IsValidationPassed = isValidationPassed = Advsrsummary.IsDisclaimerLnkDisplayed();
            //Log(string.Format("Verifying Disclaimer Link:{0}",isValidationPassed);
            return IsValidationPassed;
        }

        public bool AdvisorBVTProduction(string url, string AdvisorTitle, string IntroBlurb, string Country, string checkbox1, string checkbox2, string Radio, string Radio2, string Textbox, string hiddenQtext, string NumTextBox, string Dropdown, string Slider, string RangeSlider, string Products, string SolnName)
        {
           
            webDriver.Navigate().GoToUrl("https://www.dell.com/identity/global/in/ff92a5d1-b27a-415d-94ee-703f360b6fdb?redirectUrl=http%3a%2f%2fwww.dell.com/solutions/Configurator/us/en/g_45/amer/Internal/DSA/osc/Your-Solutions");
            Thread.Sleep(2000);
            webDriver.FindElement(By.Id("NewSolutionDialog")).Click();
            Thread.Sleep(3000);
            ReadOnlyCollection<IWebElement> modelwinodw = webDriver.FindElements(By.ClassName("modal-content"));
            foreach (var item in modelwinodw)
            {
                if (item.Text.Contains("New Solution"))
                {

                    webDriver.FindElement(By.Id("solutionName")).SendKeys("AutomationSolutionBVT");
                    new SelectElement(webDriver.FindElement(By.Id("solutionOfferCategory"))).SelectByIndex(1);
                    webDriver.FindElement(By.Id("btnNewSolutionCreate")).Click();
                    break;
                }
                

            }


            webDriver.FindElement(By.Id("composer-header-solutionbutton-save-link")).Click();

            modelwinodw = webDriver.FindElements(By.ClassName("modal-content"));
            foreach (var item in modelwinodw)
            {
                if (item.Text.Contains("Please add a product to the Solution before Saving."))
                        { return true; }
                
            }

            return false;
        }

        public bool GoogleTestINProduction()
        {
            webDriver.Navigate().GoToUrl("https://www.google.co.in/?gfe_rd=cr&ei=KABjWbWyLsPj8AeS8Iv4DQ&gws_rd=ssl#q=ISRO");

            //webDriver.FindElement(By.Name("q")).SendKeys("ISRO");

            // webDriver.FindElement(By.Name("btnK")).Click();
            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> alist = webDriver.FindElements(By.TagName("a"));
            alist.First(h => h.Text.Contains("ISRO - Government of India")).Click();
            Thread.Sleep(5000);
            Screenshot Currentscreen = ((ITakesScreenshot)webDriver).GetScreenshot();
            string screenshot = Currentscreen.AsBase64EncodedString;
            byte[] screenshotAsByteArray = Currentscreen.AsByteArray;
            Currentscreen.SaveAsFile("isroPage.jpg", ImageFormat.Png);
            //System.IO.File.WriteAllLines("currentURL.txt", new string[] { webDriver.Url.ToString() });
            return webDriver.Title.ToLower().Contains("isro");
            
        }


    }


    }
