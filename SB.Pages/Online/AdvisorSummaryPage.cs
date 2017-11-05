using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Base;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dell.Adept.UI.Web.Testing.Framework.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Drawing;
using System.Threading;
//using iTextSharp;
//using iTextSharp.text.pdf;
//using System.Web;

//using Common.Base;

namespace SB.Pages.AdvSummaryPage
{
    public class AdvisorSummaryPage: SBPageBase
    {
        IWebDriver webDriver;
        public AdvisorSummaryPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;

        }

        #region Elements
        private string SolutionId_react
        {
            get
            {
                var container = webDriver.FindElement(By.ClassName("solutionSelected"));
                var solutionID = container.FindElement(By.ClassName("gsd_subSectionHeading"));
                string SolNumber = solutionID.Text.Split('#').Last<string>();
                return SolNumber;
                //return webDriver.FindElement(By.XPath("//div[span[contains(text(),'Solution ID#')]]//span[2]"));

            }
        }

            private IWebElement SolutionId
        {
            get
            {
                    return webDriver.FindElement(By.XPath("//div[contains(text(),'Solution ID')]"));
                
            }
        }

        private IWebElement SolutionContent
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[@id='solutioncontent']//img"));
            }
        }
        private IWebElement InputSummary
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[contains(text(),'Input Summary')]"));
            }
        }
        private IWebElement PdfLnk
        {
            get
            {
                return webDriver.FindElement(By.Id("downloadpdf"));
            }
        }

        //private IWebElement confirmpdf
        //{
        //    get
        //    {
        //        return webDriver.FindElement(By.XPath("//button[contains(text(),'OK')]"));
        //    }
        //}

        private IWebElement startOverLnk
        {
            get
            {
                return webDriver.FindElement(By.Id("lnkStartover"));
            }
        }

        private IWebElement SolnNameLnk
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[contains(@class,'solutionSelected')]/div[2]"));
            }
        }

        private IWebElement Disclaimer
        {
            get
            {
                return webDriver.FindElement(By.Id("disclaimerLink"));
            }
        }
            private IWebElement Disclaimer_react
        {
            get
            {
               
                    return webDriver.FindElement(By.XPath("//a[contains(text(),'Disclaimer')]"));
            }
        }

        private IWebElement LnkViewDetails
        {
            get
            {
                return webDriver.FindElement(By.XPath("//a[contains(text(),'View Details')]"));
            }
        }

        #endregion

        public string GetSolnId()
        { 
           return SolutionId_react; 
        }

        public bool VerifyProducts(string product)
        {
            bool isdisplayed = false;
            string[] products = product.Split(',');
            LnkViewDetails.Click();
            foreach(string prod in products)
            {
                isdisplayed=webDriver.FindElement(By.XPath("//Strong[contains(text(),'"+ prod + "')]")).Displayed;
                if (!isdisplayed)
                {
                    break;
                }
            }

            return isdisplayed;

        }

        public bool VerifySolnName(string solnName)
        {
            string son = SolnNameLnk.Text;
           return son.Contains(solnName);

        }

        public bool IsPdfLnkDisplayed()
        {
            return PdfLnk.Displayed;

        }

        public bool IsstartOverLnkDisplayed()
        {
            return startOverLnk.Displayed;

        }

        public bool IsDisclaimerLnkDisplayed()
        {
                return Disclaimer_react.Displayed;
        }

        //public bool PdfDownload()
        //{
        //    string P_inputStream= "C:\\Users\\jeevitha_r2\\Desktop\\downloadPdfs\\SolutionSummary.pdf";
        //    PdfLnk.Click();
        //    webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
        //    confirmpdf.Click();
        //    PdfReader reader = new PdfReader(P_inputStream);
            
        //    if (reader.FileLength > 1000)
        //        return true;
        //    else
        //        return false; ;



        //}
        public bool VerifyInputSummary(List<string[]> summary)
        {
            bool isDisplayed = false;
            foreach (string[] a in summary)
            {

                string x= "//div[div[text()='" + a[a.Length - 2] + "'] and //div//div[text()='" + a[a.Length - 1] + "']]";
                Thread.Sleep(2000);
                IWebElement ele = webDriver.FindElement(By.XPath(x));
                isDisplayed = ele.Displayed.Equals(true);
                if (!isDisplayed)
                {
                    break;
                }

            }
            return isDisplayed;
        }

    }

}

