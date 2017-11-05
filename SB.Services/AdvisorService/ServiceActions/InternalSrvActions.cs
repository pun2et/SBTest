using SB.Services.AdvisorService.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.Services.AdvisorService.ServiceActions
{
    public class InternalSrvActions
    {
        public string Url { get; set; }

        public InternalSrvActions() { }
        public InternalSrvActions(string url)
        {
            this.Url = url;
        }

        internal AdvChannelFactory CreateProcy(String serviceUrl)
        {
            return new AdvChannelFactory(serviceUrl);
        }

        public string PingThisSerive(string serviceUrl)
        {
            return CreateProcy(serviceUrl).Ping();
        }

        public AdvisorInternalService.SolutionAdvisor GetThisAdvisor(string advName, string advVersion = "1")
        {
            return CreateProcy(Url).GetSolutionAdvisor(advName, int.Parse(advVersion));
        }

        public string GetGivenadvisorPublishStatus(string advName, string advVersion = "1")
        {
            AdvisorInternalService.SolutionAdvisor YourAdvisor = CreateProcy(Url).GetSolutionAdvisor("", int.Parse(advVersion));
            return YourAdvisor.Status.ToString(); ;
        }

        public bool UnpublishThisAdvisor(string advName)
        {
            var thisAdvisor = GetThisAdvisor(advName);
            
            AdvisorInternalService.Status thisStatus = new AdvisorInternalService.Status();
                        
             thisStatus = AdvisorInternalService.Status.Staging;
            if (thisAdvisor.Status == AdvisorInternalService.Status.Production)
            {
                return CreateProcy(Url).PublishAdvisor(thisAdvisor.AdvisorId, thisStatus, "");
            }

            return false;
        }

        public bool PublishThisAdvisor(string advName)
        {
            var thisAdvisor = GetThisAdvisor(advName);

            AdvisorInternalService.Status thisStatus = new AdvisorInternalService.Status();

            thisStatus = AdvisorInternalService.Status.Production;
            if (thisAdvisor.Status == AdvisorInternalService.Status.Staging)
            {
                return CreateProcy(Url).PublishAdvisor(thisAdvisor.AdvisorId, thisStatus, "");
            }

            return false;
        }
    }
}
