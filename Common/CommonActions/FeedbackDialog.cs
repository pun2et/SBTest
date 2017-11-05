
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Dell.Adept.UI.Web.Support.Extensions.WebDriver;
using Dell.Adept.UI.Web.Support.Extensions.WebElement;
using OpenQA.Selenium;

using Dell.Adept.UI.Web.Pages;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;
using System.Configuration;
using System.Collections.ObjectModel;



namespace SS.Utils
{
    public class FeedbackDialog
    {
        IWebDriver webDriver;

        public FeedbackDialog(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        //Need to be removed.
        private const string noThanksText = "No, thanks";

        public By DialogBy { get { return By.Id("IPEinvL"); } }
        public By DialogByAdvisor { get { return By.Id("ipeWrapper"); } }

        public IWebElement Dialog { get { return webDriver.FindElement(DialogBy); } }

        public IWebElement DialogAdvisory { get { return webDriver.FindElement(DialogByAdvisor); } }

        public IWebElement NoThanksButton
        {
            get
            {

                IWebElement feedback = null;
                try
                {
                    feedback = Dialog.FindElements(By.TagName("span")).FirstOrDefault(e => e.Text.Equals(noThanksText, StringComparison.CurrentCultureIgnoreCase));
                }
                //we are going to handel only below 2 type of exception as in above stament we are expecting them as per Application 
                catch (NoSuchElementException e) { }
                catch (ElementNotVisibleException e) { }
                return feedback == null ? feedback = DialogAdvisory.FindElement(By.TagName("map")).FindElements(By.TagName("area"))[1] : feedback;

            }
        }
        public bool IsDialogExist()
        {
            try
            {
                webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(0));
                webDriver.FindElement(DialogBy);
                return true;
            }
            catch (NoSuchElementException)
            {

                return false;
            }

        }

        public void CloseFeedBack()
        {
            if (IsDialogExist())
                NoThanksButton.Click();

        }
    }
}
