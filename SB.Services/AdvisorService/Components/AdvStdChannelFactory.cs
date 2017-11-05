using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SB.Services.AdvisorService;

namespace SB.Services.AdvisorService.Components
{
    public class AdvStdChannelFactory : IAdvisorService
    {
        #region Contructor
        
        #region CommanData

        public string Url { get; set; }
        public BasicHttpBinding Binding { get; set; }
        public EndpointAddress EndPoint { get; set; }
        public IAdvisorService AdvStdService { get; set; }
        public ChannelFactory<IAdvisorService> ChannelFactory { set; get; }

        #endregion  

        public AdvStdChannelFactory()
        {
            InitializeThisClass();
        }

        public AdvStdChannelFactory(String url)
        {
            this.Url = url;
            InitializeThisClass();
        }

        private void InitializeThisClass()
        {
            Binding = new BasicHttpBinding
            {
                MaxReceivedMessageSize = 2147483647,
                MaxBufferSize = 2147483647,
                ReaderQuotas = { MaxStringContentLength = 2147483647, MaxNameTableCharCount = 2147483647 },
                Security = { Mode = BasicHttpSecurityMode.None },
                SendTimeout = new TimeSpan(0, 9, 00)
            };
            EndPoint = new EndpointAddress(Url);
            AdvStdService = new AdvisorServiceClient(Binding, EndPoint);

            ChannelFactory = new ChannelFactory<IAdvisorService>(Binding, EndPoint);
            AdvStdService = ChannelFactory.CreateChannel();
        }
        #endregion

        #region ActionMethods

        public string Ping()
        {
            return AdvStdService.Ping();
        }

        public string LoadAdvisor(string advisorFriendlyName, string advisorVersion = "1")
        {
            AdvisorRequest advRequest = new AdvisorRequest();

            advRequest.FriendlyName = advisorFriendlyName;
            advRequest.VersionNumber = int.Parse(advisorVersion);
            return AdvStdService.LoadAdvisor(advRequest).SessionId;       
            

        }

        public void GetRecommended(string sessid)
        {
            //AdvisorStateRequest avdst = new AdvisorStateRequest();
            //UserResponse[] usrre = new UserResponse[1];

            //UserResponse rspn = new UserResponse();

            //rspn.AnswerId = "";
            //rspn.SelectedValue = "";

            //usrre[0] = rspn;


            //avdst.UserResponses = usrre;
            //var kk = AdvStdService.GetRecommendation(avdst, sessid);


            AdvisorStateRequest request = new AdvisorStateRequest();
            request.LocalizationVariables = new Dictionary<string, string>();
            request.UserResponses = new List<UserResponse>().ToArray();
            
            var kkp = AdvStdService.GetRecommendation(request, sessid);

        }

        [return: MessageParameter(Name = "AdvisorStepResponse")]
        public AdvisorStepResponse LoadSteps(AdvisorStepRequest stepRequest, string sessionId, int advisorRequestId)
        {
            return AdvStdService.LoadSteps(stepRequest, sessionId, advisorRequestId);
            
        }


        [return: MessageParameter(Name = "GetCatalogMappedAdvisors")]
        public CatalogMappedAdvisorsResponse GetCatalogMappedAdvisors(CatalogMappedAdvisorsRequest request)
        {
            return AdvStdService.GetCatalogMappedAdvisors(request);
        }

        #endregion


        #region NotImplementendMethods


        [return: MessageParameter(Name = "GetCatalogMappedAdvisors")]
        public Task<CatalogMappedAdvisorsResponse> GetCatalogMappedAdvisorsAsync(CatalogMappedAdvisorsRequest request)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorStepResponse")]
        public AdvisorStepResponse GetInputSummary(AdvisorStateRequest requestState, string sessionId, int userAdvisorRequestId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorStepResponse")]
        public Task<AdvisorStepResponse> GetInputSummaryAsync(AdvisorStateRequest requestState, string sessionId, int userAdvisorRequestId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorResponse")]
        public Dictionary<string, string> GetPremierAdvisorList(AdvisorLightweightRequest request)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorResponse")]
        public Task<Dictionary<string, string>> GetPremierAdvisorListAsync(AdvisorLightweightRequest request)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "GetRecommendationResponse")]
        public RecommendationResponse GetRecommendation(AdvisorStateRequest request, string sessionId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "GetRecommendationResponse")]
        public Task<RecommendationResponse> GetRecommendationAsync(AdvisorStateRequest request, string sessionId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "GetRecommendationResponse")]
        public RecommendationResponse GetSolutions(int userAdvisorRequestId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "GetRecommendationResponse")]
        public Task<RecommendationResponse> GetSolutionsAsync(int userAdvisorRequestId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorResponse")]
        public AdvisorResponse LoadAdvisor(AdvisorRequest request)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorResponse")]
        public Task<AdvisorResponse> LoadAdvisorAsync(AdvisorRequest request)
        {
            throw new NotImplementedException();
        }

        

        [return: MessageParameter(Name = "AdvisorStepResponse")]
        public Task<AdvisorStepResponse> LoadStepsAsync(AdvisorStepRequest stepRequest, string sessionId, int advisorRequestId)
        {
            throw new NotImplementedException();
        }

       

        public Task<string> PingAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorStateResponse")]
        public AdvisorStateResponse ProcessRequest(AdvisorStateRequest request, string sessionId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorStateResponse")]
        public Task<AdvisorStateResponse> ProcessRequestAsync(AdvisorStateRequest request, string sessionId)
        {
            throw new NotImplementedException();
        }

        public int SessionTimeLeft(string sessionId, bool extend)
        {
            throw new NotImplementedException();
        }

        public Task<int> SessionTimeLeftAsync(string sessionId, bool extend)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "FailoverDatabaseResponse")]
        public FailoverDatabaseResponse SwitchConfigFailoverDatabase(FailoverDatabaseRequest request)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "FailoverDatabaseResponse")]
        public Task<FailoverDatabaseResponse> SwitchConfigFailoverDatabaseAsync(FailoverDatabaseRequest request)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
