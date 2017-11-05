using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SB.Services.AdvisorService;
using SB.Services;
using SB.Services.AdvisorService.ServiceActions;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace SB.WorkFlow.WorkFlows
{
    public class ServiceBVTWorkFlow
    {
        private IWebDriver webDriver;
        private static bool TestStepStatus = true;

        public static bool OverAllTestResultState
        {
            get { return TestStepStatus; }
            set
            {
                if (!value)
                {

                }

                TestStepStatus = value & TestStepStatus;
            }
        }

        public ServiceBVTWorkFlow(IWebDriver driver)
        {
            this.webDriver = driver;
        }

        public ServiceBVTWorkFlow()
        {
        
        }

        public bool TestAdvExtServiceAvailibility(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string serviceURL = testContext.DataRow["AdvServiceUrl"].ToString();
            #endregion

            return !string.IsNullOrEmpty(new ExternalSrvActions().PingThisService(serviceURL));
           
        }

        public bool TestLoadAdvisorStep(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string serviceURL = testContext.DataRow["AdvServiceUrl"].ToString();
            #endregion

            AdvisorStepResponse StepResponse = new ExternalSrvActions().LoadStepForGivenAdvisor(serviceURL, advFrdName);

           return (
           StepResponse.TotalStepsAvailable.ToString() == testContext.DataRow["TotalStepsAvailable"].ToString() &&
           StepResponse.Steps[0].StepName.ToString() == testContext.DataRow["StepName"].ToString() &&
           StepResponse.Steps[0].Questions[0].AnswerType.ToString() == testContext.DataRow["AnswerType"].ToString() &&
           StepResponse.Steps[0].Questions[0].QuestionText.ToString() == testContext.DataRow["QuestionText"].ToString() &&
           StepResponse.Steps[0].Questions[0].Answers.Count().ToString() == testContext.DataRow["AnswerCount"].ToString() &&
           StepResponse.Steps[0].Questions[0].Answers[0].AnswerText.ToString() == testContext.DataRow["AnswerTextOne"].ToString() &&
           StepResponse.Steps[0].Questions[0].Answers[1].AnswerText.ToString() == testContext.DataRow["AnswerTextTwo"].ToString()
           );
            
        }

        public bool TestGetRecommendedAdvExt(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string serviceURL = testContext.DataRow["AdvServiceUrl"].ToString();
            #endregion

            string sesIDD = new ExternalSrvActions().LoadGivenAdvisor(serviceURL, advFrdName);
            new ExternalSrvActions().GetRecommendedForGivenSession(serviceURL,sesIDD);
            return true;
        }

        public bool TestIsAdvisorPublishedByMappedAdvisorsAdvExt(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string serviceURL = testContext.DataRow["AdvServiceUrl"].ToString();
            string CustomerSet = testContext.DataRow["AmerCustomerSet"].ToString();
            string LanguageCode = testContext.DataRow["AmerLanguageCode"].ToString();
            string CountryCode = testContext.DataRow["AmerCountryCode"].ToString();
            string RegionAmer = testContext.DataRow["AmerRegion"].ToString();
            #endregion
            List<AdvisorBaseDetails> ListOfAdvisors = new List<AdvisorBaseDetails>();
            ListOfAdvisors = new ExternalSrvActions().GetAdvisorBasedDetailsFor(serviceURL,CountryCode, CustomerSet, LanguageCode, RegionAmer);

            return ListOfAdvisors.Exists(g => g.FriendlyName == advFrdName);
        }

        public bool TestAdvIntServiceAvailibility(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string serviceURL = testContext.DataRow["AdvInternalService"].ToString();
            #endregion
            return !string.IsNullOrEmpty(new InternalSrvActions().PingThisSerive(serviceURL));
        }

        public bool TestAdvIntServiceLoadAndGetadvisor(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string advDisplayName = testContext.DataRow["AdvisorDisplayName"].ToString();
            string serviceURL = testContext.DataRow["AdvInternalService"].ToString(); 
            string advisorStatus = testContext.DataRow["AdvisorStatusLive"].ToString();
            string introBlurbKey = testContext.DataRow["IntroBlurbKey"].ToString();
            string introBlurbText = testContext.DataRow["IntroBlurbText"].ToString();

            string questionText = testContext.DataRow["QuestionText"].ToString();
            string answerType = testContext.DataRow["AnswerType"].ToString();
            string answerCount = testContext.DataRow["AnswerCount"].ToString();
            string answerTextOne = testContext.DataRow["AnswerTextOne"].ToString();
            string answerTextTwo = testContext.DataRow["AnswerTextTwo"].ToString();
            string stepsQuetionCount = testContext.DataRow["TotalStepsAvailable"].ToString();

            string amerProductSetCatalogID = testContext.DataRow["AmerProductSetCatalogID"].ToString();
            string amerRegion = testContext.DataRow["AmerRegion"].ToString();
            string amerComponentOne = testContext.DataRow["AmerComponentOne"].ToString();
            string amerComponentTwo = testContext.DataRow["AmerComponentTwo"].ToString();
            string amerCountryCode = testContext.DataRow["AmerCountryCode"].ToString();
            string amerCustomerSet = testContext.DataRow["AmerCustomerSet"].ToString();
            string amerLanguageCode = testContext.DataRow["AmerLanguageCode"].ToString();

            string emeaProductSetCatalogID = testContext.DataRow["EmeaProductSetCatalogID"].ToString();
            string emeaRegion = testContext.DataRow["EmeaRegion"].ToString();
            string emeaComponentOne = testContext.DataRow["EmeaComponentOne"].ToString();
            string emeaComponentTwo = testContext.DataRow["EmeaComponentTwo"].ToString();
            string emeaCountryCode = testContext.DataRow["EmeaCountryCode"].ToString();
            string emeaCustomerSet = testContext.DataRow["EmeaCustomerSet"].ToString();
            string emeaLanguageCode = testContext.DataRow["EmeaLanguageCode"].ToString();

            string apjProductSetCatalogID = testContext.DataRow["APJProductSetCatalogID"].ToString();
            string apjRegion = testContext.DataRow["APJRegion"].ToString();
            string apjComponentOne = testContext.DataRow["APJComponentOne"].ToString();
            string apjComponentTwo = testContext.DataRow["APJComponentTwo"].ToString();
            string apjCountryCode = testContext.DataRow["APJCountryCode"].ToString();
            string apjCustomerSet = testContext.DataRow["APJCustomerSet"].ToString();
            string apjLanguageCode = testContext.DataRow["APJLanguageCode"].ToString();

            string totalSolutionSets = testContext.DataRow["TotalSolutionSets"].ToString();
            string solutionSetName = testContext.DataRow["SolutionSetName"].ToString();
            string solutionSetComponentName = testContext.DataRow["SolutionSetComponent"].ToString();
            string evaluationRuleName = testContext.DataRow["EvaluationRuleName"].ToString();

            string totalProductSetsCount = testContext.DataRow["TotalProductSetsCount"].ToString();
            string evaluationRuleCount = testContext.DataRow["EvaluationRuleCount"].ToString();
            string productRuleCount = testContext.DataRow["ProductRuleCount"].ToString();


            #endregion

            var CurrentAdvisorLoaded = new InternalSrvActions(serviceURL).GetThisAdvisor(advFrdName);
            OverAllTestResultState = CurrentAdvisorLoaded.Status.ToString().Equals(advisorStatus);
            OverAllTestResultState = CurrentAdvisorLoaded.DisplayName.Equals(advDisplayName);
            OverAllTestResultState = CurrentAdvisorLoaded.IsPdfEnabled;
            OverAllTestResultState = CurrentAdvisorLoaded.Details.IntroBlurbKey.Equals(introBlurbKey);
            OverAllTestResultState = CurrentAdvisorLoaded.Details.IntroBlurb.Equals(introBlurbText);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps.Count().ToString().Equals(stepsQuetionCount);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions.Count().ToString().Equals(stepsQuetionCount);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions[0].Answers.Count().ToString().Equals(answerCount);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions[0].QuestionText.Equals(questionText);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions[0].AnswerType.ToString().Equals(answerType);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions[0].Answers[0].AnswerText.Equals(answerTextOne);
            OverAllTestResultState = CurrentAdvisorLoaded.Steps[0].Questions[0].Answers[1].AnswerText.Equals(answerTextTwo);

            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets.Count().ToString().Equals(totalProductSetsCount);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[0].CatalogId.ToString().Equals(amerProductSetCatalogID);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[0].DellRegion.ToString().Equals(amerRegion);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[0].Components[0].Key.Equals(amerComponentOne);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[0].Components[1].Key.Equals(amerComponentTwo);

            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[1].CatalogId.ToString().Equals(emeaProductSetCatalogID);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[1].DellRegion.ToString().Equals(emeaRegion);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[1].Components[0].Key.Equals(emeaComponentOne);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[1].Components[1].Key.Equals(emeaComponentTwo);

            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[2].CatalogId.ToString().Equals(apjProductSetCatalogID);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[2].DellRegion.ToString().Equals(apjRegion);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[2].Components[0].Key.Equals(apjComponentOne);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionTemplate.ProductSets[2].Components[1].Key.Equals(apjComponentTwo);

            OverAllTestResultState = CurrentAdvisorLoaded.SolutionSets.Count().ToString().Equals(totalSolutionSets);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionSets[0].LongName.Equals(solutionSetName);
            OverAllTestResultState = CurrentAdvisorLoaded.SolutionSets[0].SolutionSetComponents[0].Name.Equals(solutionSetComponentName);

            OverAllTestResultState = CurrentAdvisorLoaded.EvaluationRuleSets[0].RuleSetData.Description.Equals(evaluationRuleName);
            OverAllTestResultState = CurrentAdvisorLoaded.EvaluationRuleSets[0].RuleSetData.EvaluationRules.Length.ToString().Equals(evaluationRuleCount);
            OverAllTestResultState = CurrentAdvisorLoaded.ProductRuleSets.Length.ToString().Equals(productRuleCount);

            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails.Length.ToString().Equals(totalProductSetsCount);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[0].CountryCode.Equals(amerCountryCode);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[0].CustomerSetId.Equals(amerCustomerSet);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[0].Region.Equals(amerRegion);

            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[1].CountryCode.Equals(apjCountryCode);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[1].CustomerSetId.Equals(apjCustomerSet);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[1].Region.Equals(apjRegion);

            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[2].CountryCode.Equals(emeaCountryCode);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[2].CustomerSetId.Equals(emeaCustomerSet);
            OverAllTestResultState = CurrentAdvisorLoaded.AdvisorCatalogMapDetails[2].Region.Equals(emeaRegion);

            return OverAllTestResultState;
        }

        public bool TestAdvIntServiceSaveAndUpdateadvisor(TestContext testContext)
        {
            #region dataread
            string advFrdName = testContext.DataRow["AdvisorFriendlyName"].ToString();
            string advDisplayName = testContext.DataRow["AdvisorDisplayName"].ToString();
            string serviceURL = testContext.DataRow["AdvInternalService"].ToString();
            string advisorStatus = testContext.DataRow["AdvisorStatusLive"].ToString();
            #endregion


            //new InternalSrvActions(serviceURL).UnpublishThisAdvisor(advFrdName);

            return OverAllTestResultState;
        }
    }
}
