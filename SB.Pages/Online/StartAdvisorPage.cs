using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

using Common.Base;
using OpenQA.Selenium.Support.UI;

namespace SB.Pages.Studio
{
   public class StartAdvisorPage : SBPageBase
    {
        IWebDriver webDriver;
        public StartAdvisorPage(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;
        }
        #region elements

        private IWebElement AdvisorTitle
        {
            get
            {
                return webDriver.FindElement(By.ClassName("gsd_pageTitle"));
            }
        }

        private IWebElement IntroBlurb
        {
            get
            {
                return webDriver.FindElement(By.XPath("//div[@class='SolutionAdvDivPaddingTopLeft']/div[1]"));
            }
        }
        private IWebElement SelectCountryList
        {
            get
            {
                return webDriver.FindElement(By.Id("CountryList"));
            }
        }

        private IWebElement Language
        {
            get
            {
                return webDriver.FindElement(By.ClassName("spnLanguage"));
            }
        }

        private IWebElement StartAdvisorBtn
        {
            get
            {
                return webDriver.FindElement(By.Id("btnPrimary"));
            }
        }





        #endregion
        public void ClickStartAdvisorBtn()
        {
            StartAdvisorBtn.Click();

        }

        public string GetAdvisorTitle()
        {
            return AdvisorTitle.Text;
        }
        public string GetAdvisorIntro()
        {
            return IntroBlurb.Text;
        }

        public void SelectCountry(string country)
        {
            SelectElement s = new SelectElement(SelectCountryList);
            s.SelectByText(country);

        }
        public bool verifySBTitle(string AdvisorTitle)
        {
            return new StartAdvisorPage(webDriver).GetAdvisorTitle().Equals(AdvisorTitle);
        }

        public bool verifyIntroBlurb(string AdvisorIntroBlurb)
        {
            return new StartAdvisorPage(webDriver).GetAdvisorIntro().Equals(AdvisorIntroBlurb);

        }
    }
}
