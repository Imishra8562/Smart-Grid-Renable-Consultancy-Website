using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface IMasterManager
    {
        #region  Index Seo
        int SaveIndexSeo(Index_Seo Object);
        IList<Index_Seo> GetIndexSeo(int? Index_Seo_Id, string Index_Slug);
        int UpdateIndexSeo(Index_Seo Object);
        int DeleteIndexSeo(int Index_Seo_Id);

        #endregion

        #region Index Features
        int SaveIndexFeatures(Index_Features Object);
        IList<Index_Features_Business> GetIndexFeatures(int? Index_Features_Id, int Index_Seo_Id);
        int UpdateIndexFeatures(Index_Features Object);
        int DeleteIndexFeatures(int Index_Features_Id);

        #endregion

        #region Index Services
        int SaveIndexServices(Index_Services Object);
        IList<Index_Services_Business> GetIndexServices(int? Index_Services_Id, int Index_Seo_Id);
        int UpdateIndexServices(Index_Services Object);
        int DeleteIndexServices(int Index_Services_Id);
        #endregion

        #region Index Slider
        int SaveIndexSlider(Index_Slider Object);
        IList<Index_Slider_Business> GetIndexSlider(int? Index_Slider_Id, int Index_Seo_Id);
        int UpdateIndexSlider(Index_Slider Object);
        int DeleteIndexSlider(int Index_Slider_Id);
        #endregion

        #region Index Team
        int SaveIndexTeam(Index_Team Object);
        IList<Index_Team_Business> GetIndexTeam(int? Index_Team_Id, int Index_Seo_Id);
        int UpdateIndexTeam(Index_Team Object);
        int DeleteIndexTeam(int Index_Team_Id);
        #endregion

        #region Knowledge Base Category

        int SaveKnowledgeBaseCategory(Knowledge_Base_Category Object);
        IList<Knowledge_Base_Category> GetKnowledgeBaseCategory(int? Knowledge_Base_Category_Id, string Category_Url_Link);
        int UpdateKnowledgeBaseCategory(Knowledge_Base_Category Object);
        int DeleteKnowledgeBaseCategory(int Knowledge_Base_Category_Id);

        #endregion

        #region  Knowledge Base
        int SaveKnowledgeBase(Knowledge_Base Object);
        IList<Knowledge_Base_Business> GetKnowledgeBase(int? Knowledge_Base_Id,int? Knowledge_Base_Category_Id, string Knowledge_Base_Url_Link);
        int UpdateKnowledgeBase(Knowledge_Base Object);
        int DeleteKnowledgeBase(int Knowledge_Base_Id);
        #endregion

        #region  Knowledge Card
        int SaveKnowledgeCard(Knowledge_Card Object);
        IList<Knowledge_Card_Business> GetKnowledgeCard(int? Knowledge_Card_Id, int? Knowledge_Base_Id);
        int UpdateKnowledgeCard(Knowledge_Card Object);
        int DeleteKnowledgeCard(int Knowledge_Card_Id);
        #endregion

        #region  Knowledge FailureMode
        int SaveKnowledgeFailureMode(Knowledge_FailureMode Object);
        IList<Knowledge_FailureMode_Business> GetKnowledgeFailureMode(int? Knowledge_FailureMode_Id, int? Knowledge_Base_Id);
        int UpdateKnowledgeFailureMode(Knowledge_FailureMode Object);
        int DeleteKnowledgeFailureMode(int Knowledge_FailureMode_Id);
        #endregion

        #region  Knowledge RelatedSolution
        int SaveKnowledgeRelatedSolution(Knowledge_RelatedSolution Object);
        IList<Knowledge_RelatedSolution_Business> GetKnowledgeRelatedSolution(int? Knowledge_RelatedSolution_Id, int? Knowledge_Base_Id);
        int UpdateKnowledgeRelatedSolution(Knowledge_RelatedSolution Object);
        int DeleteKnowledgeRelatedSolution(int Knowledge_RelatedSolution_Id);
        #endregion

        #region  Knowledge WorkflowStep
        int SaveKnowledgeWorkflowStep(Knowledge_WorkflowStep Object);
        IList<Knowledge_WorkflowStep_Business> GetKnowledgeWorkflowStep(int? Knowledge_WorkflowStep_Id, int? Knowledge_Base_Id);
        int UpdateKnowledgeWorkflowStep(Knowledge_WorkflowStep Object);
        int DeleteKnowledgeWorkflowStep(int Knowledge_WorkflowStep_Id);
        #endregion

        #region  Engineering Services
        int SaveEngineeringServices(Engineering_Services Object);
        IList<Engineering_Services> GetEngineeringServices(int? Engineering_Services_Id, string Engineering_Services_Url_Link);
        int UpdateEngineeringServices(Engineering_Services Object);
        int DeleteEngineeringServices(int Engineering_Services_Id);
        #endregion

        #region Engineering Services Features

        int SaveEngineeringServicesFeatures(Engineering_Services_Features Object);
        IList<Engineering_Services_Features> GetEngineeringServicesFeatures(int? Engineering_Services_Features_Id, int? Engineering_Services_Id);
        int UpdateEngineeringServicesFeatures(Engineering_Services_Features Object);
        int DeleteEngineeringServicesFeatures(int Engineering_Services_Features_Id);
        #endregion

        #region Engineering Services SubTopic
        int SaveEngineeringServicesSubTopic(Engineering_Services_SubTopic Object);
        IList<Engineering_Services_SubTopic> GetEngineeringServicesSubTopic(int? Engineering_Services_SubTopic_Id, int? Engineering_Services_Id);
        int UpdateEngineeringServicesSubTopic(Engineering_Services_SubTopic Object);
        int DeleteEngineeringServicesSubTopic(int Engineering_Services_SubTopic_Id);
        #endregion

        #region Engineering Services Gallery
        int SaveEngineeringServicesGallery(Engineering_Services_Gallery Object);
        IList<Engineering_Services_Gallery> GetEngineeringServicesGallery(int? Engineering_Services_Gallery_Id, int? Engineering_Services_Id);
        int UpdateEngineeringServicesGallery(Engineering_Services_Gallery Object);
        int DeleteEngineeringServicesGallery(int Engineering_Services_Gallery_Id);
        #endregion

        #region Engineering Services Applications
        int SaveEngineeringServicesApplications(Engineering_Services_Applications Object);
        IList<Engineering_Services_Applications> GetEngineeringServicesApplications(int? Engineering_Services_Applications_Id, int? Engineering_Services_Id);
        int UpdateEngineeringServicesApplications(Engineering_Services_Applications Object);
        int DeleteEngineeringServicesApplications(int Engineering_Services_Applications_Id);
        #endregion

        #region Engineering Services Tabs
        int SaveEngineeringServicesTabs(Engineering_Services_Tabs Object);
        IList<Engineering_Services_Tabs> GetEngineeringServicesTabs(int? Engineering_Services_Tabs_Id, int? Engineering_Services_Id);
        int UpdateEngineeringServicesTabs(Engineering_Services_Tabs Object);
        int DeleteEngineeringServicesTabs(int Engineering_Services_Tabs_Id);
        #endregion

        #region  EngSer Gallery
        int SaveEngSerGallery(EngSer_Gallery Object);
        IList<EngSer_Gallery> GetEngSerGallery(int? EngSer_Gallery_Id, int? Engineering_Services_Id);
        int UpdateEngSerGallery(EngSer_Gallery Object);
        int DeleteEngSerGallery(int EngSer_Gallery_Id);

        #endregion

    }

}
