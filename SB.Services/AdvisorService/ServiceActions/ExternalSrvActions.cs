using Microsoft.VisualStudio.TestTools.UnitTesting;
using SB.Services.AdvisorService.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.AdvisorService.ServiceActions
{
   public class ExternalSrvActions
    {
        public string Url { get; set; }

        public string RequestOrigin { get; set; }
        public ExternalSrvActions()
        {
        }

        public ExternalSrvActions(string url)
        {
            this.Url = url;

        }

        internal AdvStdChannelFactory CreateProxy(string serviceUrl)
        {
            return new AdvStdChannelFactory(serviceUrl);
        }

        public string PingThisService(string serviceUrl)
        {
            AdvStdChannelFactory stdfacory = new AdvStdChannelFactory(serviceUrl);
           return stdfacory.Ping();

        }

        public string LoadGivenAdvisor(string serviceUrl,string advisorFriendlyName)
        {
            AdvStdChannelFactory stdfacory = new AdvStdChannelFactory(serviceUrl);
            return stdfacory.LoadAdvisor(advisorFriendlyName);
        }

        public AdvisorStepResponse LoadStepForGivenAdvisor(string serviceUrl,string advisorFriendlyName, int advisorVersion = 1)
        {
            AdvStdChannelFactory stdfacory = new AdvStdChannelFactory(serviceUrl);
            string SessionId = LoadGivenAdvisor(serviceUrl, advisorFriendlyName);
            AdvisorStepRequest steprequest = new AdvisorStepRequest();
            steprequest.FriendlyName = advisorFriendlyName;
            steprequest.Version = advisorVersion;
            return stdfacory.LoadSteps(steprequest, SessionId,0);            
        }
        public void GetRecommendedForGivenSession(string serviceUrl,string sessionId)
        {
            AdvStdChannelFactory stdfacory = new AdvStdChannelFactory(serviceUrl);
            stdfacory.GetRecommended(sessionId);
        }

        public List<AdvisorBaseDetails> GetAdvisorBasedDetailsFor(string serviceUrl, string countryCode, string customerSet, string languageCode, string region)
        {
            AdvStdChannelFactory stdfacory = new AdvStdChannelFactory(serviceUrl);
            CatalogMappedAdvisorsRequest CatMapAdvRequest = new CatalogMappedAdvisorsRequest();
            CatMapAdvRequest.CountryCode = countryCode;
            CatMapAdvRequest.CustomerSetId = customerSet;
            CatMapAdvRequest.LanguageCode = languageCode;
            CatMapAdvRequest.Region = region;
            CatalogMappedAdvisorsResponse CatMapAdvResponse = stdfacory.GetCatalogMappedAdvisors(CatMapAdvRequest);
            return CatMapAdvResponse.AdvisorBaseDetails.ToList<AdvisorBaseDetails>();
        }
    }
}
