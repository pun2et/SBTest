using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

using SB.Services.AdvisorInternalService;

namespace SB.Services.AdvisorService.Components
{
    public class AdvChannelFactory : IAdvisorInternalService
    {

        #region Contructor 

        #region CommonData
        public string Url { set; get; }

        public BasicHttpBinding Binding { set; get; }

        public EndpointAddress Endpoint { set; get; }

        public IAdvisorInternalService AdvInternalService { get; set; }

        public ChannelFactory<IAdvisorInternalService> ChannelFactory { set; get; }

     

        public AdvChannelFactory()
        {
            InitializeThisClass();
        }

        public AdvChannelFactory(string url)
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
                SendTimeout = new TimeSpan(0, 3, 00)
            };
            Endpoint = new EndpointAddress(Url);
            AdvInternalService = new AdvisorInternalServiceClient(Binding, Endpoint);

            ChannelFactory = new ChannelFactory<IAdvisorInternalService>(Binding, Endpoint);
            AdvInternalService = ChannelFactory.CreateChannel();
        }
        #endregion

        #endregion
        #region ImplimententMethods

        [return: MessageParameter(Name = "CurrentTimeStamp")]
        public string Ping()
        {
            return AdvInternalService.Ping();
        }

        [return: MessageParameter(Name = "SolutionAdvisor")]
        public SolutionAdvisor GetSolutionAdvisor(string AdvisorFriendlyName, int Version)
        {
            return AdvInternalService.GetSolutionAdvisor(AdvisorFriendlyName, Version);
        }


        public bool PublishAdvisor(Guid AdvisorId, Status Status, string User = "")
        {
            return AdvInternalService.PublishAdvisor(AdvisorId, Status, User);
        }


        #endregion


        #region NotImplementedMethods

        public void AssociateAdvisorUserRole(string NTLogin, UserRoleType AdvisorRole, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task AssociateAdvisorUserRoleAsync(string NTLogin, UserRoleType AdvisorRole, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public ProductSet CloneProductSet(Guid productSetId, Guid templateId, DellRegion region, string country, string customerSet, int catalogId, string name, string description, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public Task<ProductSet> CloneProductSetAsync(Guid productSetId, Guid templateId, DellRegion region, string country, string customerSet, int catalogId, string name, string description, bool isDefault)
        {
            throw new NotImplementedException();
        }

        public SolutionSet CloneSolution(Guid AdvisorId, Guid SolutionSetId, string CreatedBy)
        {
            throw new NotImplementedException();
        }

        public Task<SolutionSet> CloneSolutionAsync(Guid AdvisorId, Guid SolutionSetId, string CreatedBy)
        {
            throw new NotImplementedException();
        }

        public AdvisorInternalService.Step CloneStep(Guid AdvisorId, Guid StepId, string CreatedBy)
        {
            throw new NotImplementedException();
        }

        public Task<AdvisorInternalService.Step> CloneStepAsync(Guid AdvisorId, Guid StepId, string CreatedBy)
        {
            throw new NotImplementedException();
        }

        public void CopyAdvisor(Guid AdvisorId, string FriendlyName, bool IsNewAdvisor, bool IsCrossEnvironment, bool IsDeleteExistingAdvisor, SolutionAdvisor AdvisorToCopy, string CreatedBy, bool IsToCopyCMS)
        {
            throw new NotImplementedException();
        }

        public Task CopyAdvisorAsync(Guid AdvisorId, string FriendlyName, bool IsNewAdvisor, bool IsCrossEnvironment, bool IsDeleteExistingAdvisor, SolutionAdvisor AdvisorToCopy, string CreatedBy, bool IsToCopyCMS)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdditionalInfo(Guid AdditionalInfoId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdditionalInfoAsync(Guid AdditionalInfoId)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdvisor(Guid AdvisorId, string CurrentUserNTLogin)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdvisorAccess(Guid AdvisorInstanceId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdvisorAccessAsync(Guid AdvisorInstanceId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdvisorAsync(Guid AdvisorId, string CurrentUserNTLogin)
        {
            throw new NotImplementedException();
        }

        public void DeleteAdvisorUser(string NTLogin)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAdvisorUserAsync(string NTLogin)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllSpreadsheetsByAdvisorId(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAllSpreadsheetsByAdvisorIdAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public void DeleteEvaluationRuleSet(Guid EvaluationRuleSetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEvaluationRuleSetAsync(Guid EvaluationRuleSetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteNews(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteNewsAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductRuleSet(Guid ProductRuleSetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductRuleSetAsync(Guid ProductRuleSetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductSet(Guid ProductSetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductSetAsync(Guid ProductSetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteQuestion(Guid QuestionId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteQuestionAsync(Guid QuestionId)
        {
            throw new NotImplementedException();
        }

        public void DeleteRuleSet(Guid RuleSetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRuleSetAsync(Guid RuleSetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSolutionSet(Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSolutionSetAsync(Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSolutionSetComponent(Guid SolutionSetComponentId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSolutionSetComponentAsync(Guid SolutionSetComponentId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpreadsheetByIds(Guid SpreadsheetId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSpreadsheetByIdsAsync(Guid SpreadsheetId)
        {
            throw new NotImplementedException();
        }

        public void DeleteSpreadSheetCustomFunction(Guid CustomFunctionId, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSpreadSheetCustomFunctionAsync(Guid CustomFunctionId, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public void DeleteStep(Guid StepId)
        {
            throw new NotImplementedException();
        }

        public Task DeleteStepAsync(Guid StepId)
        {
            throw new NotImplementedException();
        }

        public SpreadsheetReponse DownloadSpreadsheet(SpreadsheetDownloadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SpreadsheetReponse> DownloadSpreadsheetAsync(SpreadsheetDownloadRequest request)
        {
            throw new NotImplementedException();
        }

        public AdvisorAccess[] GetAdvisorAccess(Guid AdvisorInstanceId, string Owner)
        {
            throw new NotImplementedException();
        }

        public Task<AdvisorAccess[]> GetAdvisorAccessAsync(Guid AdvisorInstanceId, string Owner)
        {
            throw new NotImplementedException();
        }

        public CMSAdvisor GetAdvisorForCMS(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task<CMSAdvisor> GetAdvisorForCMSAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CMSAdvisor")]
        public CMSAdvisor GetAdvisorFromCMS(GlobalizationInfo GlobalizationInfo, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CMSAdvisor")]
        public Task<CMSAdvisor> GetAdvisorFromCMSAsync(GlobalizationInfo GlobalizationInfo, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorMessages")]
        public AdvisorInternalService.AdvisorMessage[] GetAdvisorMessages(Guid advisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorMessages")]
        public Task<AdvisorInternalService.AdvisorMessage[]> GetAdvisorMessagesAsync(Guid advisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorHeader")]
        public AdvisorHeader[] GetAdvisorsByFriendlyName(string AdvisorFriendlyName)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorHeader")]
        public Task<AdvisorHeader[]> GetAdvisorsByFriendlyNameAsync(string AdvisorFriendlyName)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorHeader")]
        public AdvisorHeader[] GetAdvisorsByType(AdvisorInternalService.AdvisorType AdvisorType)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorHeader")]
        public Task<AdvisorHeader[]> GetAdvisorsByTypeAsync(AdvisorInternalService.AdvisorType AdvisorType)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorUserProfile")]
        public AdvisorUserProfile GetAdvisorUserProfile(string NTLogin)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorUserProfile")]
        public Task<AdvisorUserProfile> GetAdvisorUserProfileAsync(string NTLogin)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorUser")]
        public AdvisorUser[] GetAdvisorUsers()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorUser")]
        public Task<AdvisorUser[]> GetAdvisorUsersAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "InciteAtrributes")]
        public AdvisorInternalService.InciteAttribute[] GetAttributesByChassisIdModuleId(int ChassisId, int ModuleId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "InciteAtrributes")]
        public Task<AdvisorInternalService.InciteAttribute[]> GetAttributesByChassisIdModuleIdAsync(int ChassisId, int ModuleId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CatalogDetails")]
        public Catalog GetCatalogDetails(int CatalogId, bool IncludePremier, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CatalogDetails")]
        public Task<Catalog> GetCatalogDetailsAsync(int CatalogId, bool IncludePremier, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Catalogs")]
        public Catalog[] GetCatalogsByRegion(DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Catalogs")]
        public Task<Catalog[]> GetCatalogsByRegionAsync(DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ConfigProduct")]
        public AdvisorInternalService.ConfigProduct GetComponentProductDetails(string OrderCodeId, string Region, string CustomerSetId, string CountryCode, string LanguageCode, bool IncludeValidationAttributes)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ConfigProduct")]
        public Task<AdvisorInternalService.ConfigProduct> GetComponentProductDetailsAsync(string OrderCodeId, string Region, string CustomerSetId, string CountryCode, string LanguageCode, bool IncludeValidationAttributes)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Contents")]
        public DynamicContent[] GetDynamicContents(Guid advisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Contents")]
        public Task<DynamicContent[]> GetDynamicContentsAsync(Guid advisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "EvaluationRuleSets")]
        public EvaluationRuleSet[] GetEvaluationRuleSetsByAdvisorId(Guid AdvisorId, Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "EvaluationRuleSets")]
        public Task<EvaluationRuleSet[]> GetEvaluationRuleSetsByAdvisorIdAsync(Guid AdvisorId, Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LocalizationAttributes")]
        public LocalizationAttributes[] GetLocalizationAttributes()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LocalizationAttributes")]
        public Task<LocalizationAttributes[]> GetLocalizationAttributesAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ConfigModules")]
        public AdvisorInternalService.ConfigModule[] GetModulesByChassisId(int ChassisId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ConfigModules")]
        public Task<AdvisorInternalService.ConfigModule[]> GetModulesByChassisIdAsync(int ChassisId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "News")]
        public News[] GetNews()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "News")]
        public Task<News[]> GetNewsAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LineItems")]
        public AdvisorInternalService.ComponentLineItem[] GetNonTiedLineItemSkus(string CommaSeparatedSkuList, int CatalogId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LineItems")]
        public Task<AdvisorInternalService.ComponentLineItem[]> GetNonTiedLineItemSkusAsync(string CommaSeparatedSkuList, int CatalogId, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        public CMSProcessStatusResponse GetProcessStatus(Guid notificationId)
        {
            throw new NotImplementedException();
        }

        public Task<CMSProcessStatusResponse> GetProcessStatusAsync(Guid notificationId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductRuleSets")]
        public ProductRuleSet[] GetProductRuleSetsByAdvisorId(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductRuleSets")]
        public Task<ProductRuleSet[]> GetProductRuleSetsByAdvisorIdAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductSet")]
        public ProductSet[] GetProductSetsByTemplateId(Guid TemplateId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductSet")]
        public Task<ProductSet[]> GetProductSetsByTemplateIdAsync(Guid TemplateId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductTree")]
        public ProductTree GetProductTreeByCatalogId(int CatalogId, bool IncludeOnlyDellstarOrderCodes, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "ProductTree")]
        public Task<ProductTree> GetProductTreeByCatalogIdAsync(int CatalogId, bool IncludeOnlyDellstarOrderCodes, DellRegion Region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "RuleSet")]
        public AdvisorInternalService.RuleSet GetQuestionRuleSet(Guid QuestionId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "RuleSet")]
        public Task<AdvisorInternalService.RuleSet> GetQuestionRuleSetAsync(Guid QuestionId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "RegExpressions")]
        public AdvisorInternalService.RegExpression[] GetRegularExpressions()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "RegExpressions")]
        public Task<AdvisorInternalService.RegExpression[]> GetRegularExpressionsAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionResponse")]
        public SolutionResponse GetSolution(SolutionRequest SolutionRequest)
        {
            throw new NotImplementedException();
        }

        
        [return: MessageParameter(Name = "SolutionAdvisor")]
        public Task<SolutionAdvisor> GetSolutionAdvisorAsync(string AdvisorFriendlyName, int Version)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionResponse")]
        public Task<SolutionResponse> GetSolutionAsync(SolutionRequest SolutionRequest)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionSets")]
        public SolutionSet[] GetSolutionSetsByAdvisorId(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionSets")]
        public Task<SolutionSet[]> GetSolutionSetsByAdvisorIdAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTemplate")]
        public SolutionTemplate GetSolutionTemplateByAdvisorId(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTemplate")]
        public Task<SolutionTemplate> GetSolutionTemplateByAdvisorIdAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTreeResponse")]
        public SolutionTreeResponse GetSolutionTemplateTree(SolutionTemplateTreeRequest SolutionTemplateTreeRequest)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTreeResponse")]
        public Task<SolutionTreeResponse> GetSolutionTemplateTreeAsync(SolutionTemplateTreeRequest SolutionTemplateTreeRequest)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTemplateType")]
        public SolutionTemplateType[] GetSolutionTemplateTypes(Region region)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionTemplateType")]
        public Task<SolutionTemplateType[]> GetSolutionTemplateTypesAsync(Region region)
        {
            throw new NotImplementedException();
        }

        public SpreadsheetCustomFunction[] GetSpreadSheetCustomFunctions(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task<SpreadsheetCustomFunction[]> GetSpreadSheetCustomFunctionsAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Spreadsheet[] GetSpreadsheetsInfoByAdvisorId(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task<Spreadsheet[]> GetSpreadsheetsInfoByAdvisorIdAsync(Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public AdvisorInternalService.ComponentLineItem[] GetTiedSkus(string Region, string CommaSeparatedSkuList, int CatalogId, string CurrencyCode, string CustomerSetId, string LanguageId, string CountryCode)
        {
            throw new NotImplementedException();
        }

        public Task<AdvisorInternalService.ComponentLineItem[]> GetTiedSkusAsync(string Region, string CommaSeparatedSkuList, int CatalogId, string CurrencyCode, string CustomerSetId, string LanguageId, string CountryCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Advisor")]
        public Advisor[] GetUniqueAdvisors(AdvisorInternalService.AdvisorType AdvisorType)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "Advisor")]
        public Task<Advisor[]> GetUniqueAdvisorsAsync(AdvisorInternalService.AdvisorType AdvisorType)
        {
            throw new NotImplementedException();
        }

        public CMSNotifyResponse NotifyChange(CMSNotifyRequest notifyRequest, string currentUserNTLogin)
        {
            throw new NotImplementedException();
        }

        public Task<CMSNotifyResponse> NotifyChangeAsync(CMSNotifyRequest notifyRequest, string currentUserNTLogin)
        {
            throw new NotImplementedException();
        }

        

        [return: MessageParameter(Name = "CurrentTimeStamp")]
        public Task<string> PingAsync()
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CountriesByRegion")]
        public Country[] PopulateCountriesByRegion(DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CountriesByRegion")]
        public Task<Country[]> PopulateCountriesByRegionAsync(DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CustomersetByCountry")]
        public CustomerSet[] PopulateCustomersetByCountry(string countryCode, string languageCode, DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "CustomersetByCountry")]
        public Task<CustomerSet[]> PopulateCustomersetByCountryAsync(string countryCode, string languageCode, DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LanguagesByCountry")]
        public Language[] PopulateLanguagesByCountry(string countryCode, DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "LanguagesByCountry")]
        public Task<Language[]> PopulateLanguagesByCountryAsync(string countryCode, DellRegion regionCode)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PublishAdvisorAsync(Guid AdvisorId, Status Status, string User)
        {
            throw new NotImplementedException();
        }

        public void SaveAdditionalInfo(AdvisorInternalService.AdditionalInfo AdditionalInfo)
        {
            throw new NotImplementedException();
        }

        public Task SaveAdditionalInfoAsync(AdvisorInternalService.AdditionalInfo AdditionalInfo)
        {
            throw new NotImplementedException();
        }

        public void SaveAdvisorAccess(string NtLogin, string user, Guid advisorID)
        {
            throw new NotImplementedException();
        }

        public Task SaveAdvisorAccessAsync(string NtLogin, string user, Guid advisorID)
        {
            throw new NotImplementedException();
        }

        public void SaveAdvisorIntroDetails(AdvisorInternalService.IntroDetail AdvisorIntroDetails)
        {
            throw new NotImplementedException();
        }

        public Task SaveAdvisorIntroDetailsAsync(AdvisorInternalService.IntroDetail AdvisorIntroDetails)
        {
            throw new NotImplementedException();
        }

        public void SaveAdvisorUser(AdvisorUser AdvisorUser)
        {
            throw new NotImplementedException();
        }

        public Task SaveAdvisorUserAsync(AdvisorUser AdvisorUser)
        {
            throw new NotImplementedException();
        }

        public void SaveAdvisorUserConfiguration(string NTLogin, AdvisorUserConfiguration AdvisorUserConfiguration, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task SaveAdvisorUserConfigurationAsync(string NTLogin, AdvisorUserConfiguration AdvisorUserConfiguration, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorCatalogMap")]
        public bool SaveCatalogMappedDetails(AdvisorCatalogMap[] catalogDetailsList, Guid advisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorCatalogMap")]
        public Task<bool> SaveCatalogMappedDetailsAsync(AdvisorCatalogMap[] catalogDetailsList, Guid advisorId)
        {
            throw new NotImplementedException();
        }

        public void SaveEvaluationRuleSet(EvaluationRuleSet EvaluationRuleSet)
        {
            throw new NotImplementedException();
        }

        public Task SaveEvaluationRuleSetAsync(EvaluationRuleSet EvaluationRuleSet)
        {
            throw new NotImplementedException();
        }

        public void SaveNews(News News)
        {
            throw new NotImplementedException();
        }

        public Task SaveNewsAsync(News News)
        {
            throw new NotImplementedException();
        }

        public void SaveProductRuleSet(ProductRuleSet ProductRuleSet, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task SaveProductRuleSetAsync(ProductRuleSet ProductRuleSet, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public void SaveProductSet(ProductSet ProductSet, Guid TemplateId)
        {
            throw new NotImplementedException();
        }

        public Task SaveProductSetAsync(ProductSet ProductSet, Guid TemplateId)
        {
            throw new NotImplementedException();
        }

        public void SaveQuestion(AdvisorInternalService.Question question)
        {
            throw new NotImplementedException();
        }

        public Task SaveQuestionAsync(AdvisorInternalService.Question question)
        {
            throw new NotImplementedException();
        }

        public void SaveQuestionRuleSet(Guid QuestionId, AdvisorInternalService.RuleSet RuleSet)
        {
            throw new NotImplementedException();
        }

        public Task SaveQuestionRuleSetAsync(Guid QuestionId, AdvisorInternalService.RuleSet RuleSet)
        {
            throw new NotImplementedException();
        }

        public void SaveQuestionSteps(AdvisorInternalService.Step step)
        {
            throw new NotImplementedException();
        }

        public Task SaveQuestionStepsAsync(AdvisorInternalService.Step step)
        {
            throw new NotImplementedException();
        }

        public void SaveSolutionAdvisor(SolutionAdvisor solutionAdvisor)
        {
            throw new NotImplementedException();
        }

        public Task SaveSolutionAdvisorAsync(SolutionAdvisor solutionAdvisor)
        {
            throw new NotImplementedException();
        }

        public void SaveSolutionSet(SolutionSet SolutionSet, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task SaveSolutionSetAsync(SolutionSet SolutionSet, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public void SaveSolutionSetComponent(AdvisorInternalService.SolutionSetComponent SolutionSetComponent, Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        public Task SaveSolutionSetComponentAsync(AdvisorInternalService.SolutionSetComponent SolutionSetComponent, Guid SolutionSetId)
        {
            throw new NotImplementedException();
        }

        public void SaveSolutionTemplate(SolutionTemplate SolutionTemplate, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task SaveSolutionTemplateAsync(SolutionTemplate SolutionTemplate, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public CompileError[] SaveSpreadSheetCustomFunction(SpreadsheetCustomFunction CustomFunction, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task<CompileError[]> SaveSpreadSheetCustomFunctionAsync(SpreadsheetCustomFunction CustomFunction, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorSearchResult")]
        public AdvisorHeader[] SearchAdvisor(AdvisorSearchCriteria AdvisorSearchCriteria)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "AdvisorSearchResult")]
        public Task<AdvisorHeader[]> SearchAdvisorAsync(AdvisorSearchCriteria AdvisorSearchCriteria)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdvisorMessages(Guid advisorId, AdvisorInternalService.AdvisorMessage[] advisorMessages)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAdvisorMessagesAsync(Guid advisorId, AdvisorInternalService.AdvisorMessage[] advisorMessages)
        {
            throw new NotImplementedException();
        }

        public void UpdateDynamicContents(Guid advisorId, DynamicContent[] contents)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDynamicContentsAsync(Guid advisorId, DynamicContent[] contents)
        {
            throw new NotImplementedException();
        }

        public void UpdateSequence(StepSequence[] StepSequenceList, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSequenceAsync(StepSequence[] StepSequenceList, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public void UpdateSolutionSequence(SolutionSequence[] SolutionSequenceList, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSolutionSequenceAsync(SolutionSequence[] SolutionSequenceList, string ModifiedBy)
        {
            throw new NotImplementedException();
        }

        public SpreadsheetMessage UploadSpreadSheet(SpreadsheetUploadRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<SpreadsheetMessage> UploadSpreadSheetAsync(SpreadsheetUploadRequest request)
        {
            throw new NotImplementedException();
        }

        public bool ValidateAdvisorAccess(string NTLogin, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateAdvisorAccessAsync(string NTLogin, Guid AdvisorId)
        {
            throw new NotImplementedException();
        }

        public bool ValidateKey(string Key, KeyType KeyType)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateKeyAsync(string Key, KeyType KeyType)
        {
            throw new NotImplementedException();
        }

        public bool ValidateNTLogin(string NTLogin)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ValidateNTLoginAsync(string NTLogin)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionAdvisorValidationResult")]
        public SolutionAdvisorValidationResult ValidateSolutionAdvisor(string AdvisorFriendlyName, int Version)
        {
            throw new NotImplementedException();
        }

        [return: MessageParameter(Name = "SolutionAdvisorValidationResult")]
        public Task<SolutionAdvisorValidationResult> ValidateSolutionAdvisorAsync(string AdvisorFriendlyName, int Version)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
