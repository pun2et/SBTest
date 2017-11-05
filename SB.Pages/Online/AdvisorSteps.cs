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
using Microsoft.VisualStudio.TestTools.UnitTesting;


//using Common.Base;

namespace SB.Pages
{
    public class AdvisorSteps: SBPageBase
    {
        IWebDriver webDriver;
        public AdvisorSteps(IWebDriver webDriver) : base(webDriver)
        {
            this.webDriver = webDriver;

        }
        #region elements
        private IWebElement NextButton
        {
            get
            {
                return webDriver.FindElement(By.Id("btnSolutionAdvStepNext"));

            }
        }
        private IWebElement GetRecommendation
        {
            get
            {
                return webDriver.FindElement(By.Id("btnGetRecommendation"));

            }
        }

        private IWebElement PreviousButton
        {
            get
            {
                return webDriver.FindElement(By.Id("btnSolutionAdvStepPrevious"));

            }
        }
        private IWebElement Currentstep
        {
            get
            {
                return webDriver.FindElement(By.ClassName("SolutionAdvStepsHeaderSelected"));

            }
        }

        private IWebElement Currenttooltip
        {
            get
            {
                By be1 = By.XPath("//div[@class='tbtsBody clearfix']");
                return webDriver.FindElement(be1);

            }
        }




        #endregion
        #region Answer components
        public bool selectCheckbox(string QuestionText,string AnsText)
        {
            IWebElement checkbox =webDriver.FindElement(By.XPath("//div[div[contains(text(),'"+ QuestionText + "')]]//tr[td/label[contains(text(),'"+ AnsText + "')]]/td[input[@type='checkbox']]"));
            Thread.Sleep(2000);
            checkbox.Click();
            return checkbox.Selected;
        }
        public IWebElement Radiobutton(string QuestionText, string AnsText)
        {
            return webDriver.FindElement(By.XPath("//div[div[contains(text(),'" + QuestionText + "')]]//div[div[label[contains(text(),'" + AnsText + "')]]]//input[@type='radio']"));
        }
        public bool selectRadioButton(string QuestionText, string AnsText)
        {
            IWebElement Radbutton= new AdvisorSteps(webDriver).Radiobutton(QuestionText, AnsText);
            Thread.Sleep(2000);
            Radbutton.Click();
            return Radbutton.Selected;
        }

        public void Textbox(string QuestionText, string TextboxName, string Text)
        {
            IWebElement TextBox = webDriver.FindElement(By.XPath("//div[div[contains(text(),'"+ QuestionText + "')]]//tr[td//*[contains(text(),'"+ TextboxName + "')]]//input[@type='text']"));
            Thread.Sleep(2000);
            TextBox.Clear();
            TextBox.SendKeys(Text);
        }
        public bool DropDown(string QuestionText, string option)
        {
            IWebElement DropDown = webDriver.FindElement(By.XPath("//div[div[contains(text(),'" + QuestionText + "')][contains(@id,'QuestionText')]]//select[contains(@id,'AnswerDropDownList')]/option[contains(text(),'" + option +"')]"));
            Thread.Sleep(2000);
            DropDown.Click();
            return DropDown.Selected;
        }

        public void Slider(string Anstext, int target)
        {            
            IWebElement slider = webDriver.FindElement(By.XPath("//div[div[div[contains(text(),'" + Anstext + "')]]]//div[contains(@id,'AnswerSlider')]//a"));
            OpenQA.Selenium.Interactions.Actions aa = new OpenQA.Selenium.Interactions.Actions(webDriver);
            aa.DragAndDropToOffset(slider, target, 0).Perform();
        }

        public void RangeSlider(string AnsText, int min, int max)
        {
            IReadOnlyCollection<IWebElement> sliders = webDriver.FindElements(By.XPath("//div[div[contains(text(),'Range Slider Question TExt')][contains(@id,'soluionAdvQuestionText')]]//div[contains(@id,'AnswerSlider')]//a"));
            IWebElement slide = webDriver.FindElement(By.XPath("//div[contains(@id,'ansPanal')]"));
            int width = slide.Size.Width;                       
            Actions act = new Actions(webDriver);
            act.DragAndDropToOffset(sliders.ElementAt(1), ((width * max) / 100), 0).Perform();
            act.DragAndDropToOffset(sliders.ElementAt(0), ((width * (min*-1)) / 100), 0).Perform();
            
        }
        public void ClickStartAdvisorBtn()
        {
           
        }

        public string Gettooltip(Actions a)
        {

            Thread.Sleep(8000);
            IWebElement toolTipElement = webDriver.FindElement(By.XPath("//div[@class='gray-tooltip steplink SolutionAdvStepsHeaderSelected']"));
            a.MoveToElement(toolTipElement, 0, 0).Perform();
            toolTipElement.Click();
            a.Click().Build().Perform();
            //Thread.Sleep(8000);
            By be1 = By.XPath("//div[@class='tbtsBody clearfix']");
            IWebElement tooltip = webDriver.FindElement(be1);
            return tooltip.Text;
        }

        public void ClickNextBtn()
        {
            NextButton.Click();
        }
        public void ClickPrevBtn()
        {
            PreviousButton.Click();
        }
        public void ClickGetRecommendation()
        {
            Thread.Sleep(3000);
            GetRecommendation.Click();
            Thread.Sleep(5000);
        }

        public void ClickStepNumber(string stepnumber)
        {
            IWebElement step;
            try
            {
                
                step = webDriver.FindElement(By.XPath("//div[contains(@class,'SolutionAdvStepsHeader')][contains(text(),'" + stepnumber + "')]"));
            }
            catch//(OpenQA.Selenium.NoSuchElementException e)
            {
                step = webDriver.FindElement(By.XPath("//a[contains(text(),'" + stepnumber + "')]"));
            }
            Actions a = new Actions(webDriver);
            //a.ClickAndHold(step);
            step.Click();
            Thread.Sleep(5000);            
        }

        public string[] QnA(string QnA)
        {
            string[] parameters = QnA.Split(',');
            return parameters;
        }

        public bool verifyRadioButtondisabled(string Question, string Ans)
        {
            return new AdvisorSteps(WebDriver).Radiobutton(Question, Ans).Enabled.Equals(false);
        }

        public bool IsQuestionhidden(string QuestionText)
        {
            try
            {
                webDriver.FindElement(By.XPath("'//div[contains(text(),'" + QuestionText + "')]"));
                return false;
            }catch(NoSuchElementException e)
            {
                return true;
            }
        }
        #endregion

    }

}

