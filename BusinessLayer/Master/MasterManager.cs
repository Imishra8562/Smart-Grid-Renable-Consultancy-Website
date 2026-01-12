using BusinessLayer.Interface;
using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;


namespace BusinessLayer
{
    public class MasterManager :IMasterManager
    {
        #region Index Seo

        public int SaveIndexSeo(Index_Seo Object)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Seo> GetIndexSeo(int? Index_Seo_Id, string Index_Seo_Slug)
        {
            IList<Index_Seo> ListObj = new List<Index_Seo>();
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                ListObj = db.ListIndexSeo(Index_Seo_Id, Index_Seo_Slug);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexSeo(Index_Seo Object)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexSeo(int Index_Seo_Id)
        {
            int Id = 0;
            try
            {
                Index_Seo_Repository db = new Index_Seo_Repository();
                Id = db.Delete(Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region Index Features
        public int SaveIndexFeatures(Index_Features Object)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Features_Business> GetIndexFeatures(int? Index_Features_Id, int Index_Seo_Id)
        {
            IList<Index_Features_Business> ListObj = new List<Index_Features_Business>();
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                ListObj = db.ListIndexFeatures(Index_Features_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexFeatures(Index_Features Object)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexFeatures(int Index_Features_Id)
        {
            int Id = 0;
            try
            {
                Index_Features_Repository db = new Index_Features_Repository();
                Id = db.Delete(Index_Features_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion
            
        #region Index Services
        public int SaveIndexServices(Index_Services Object)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Services_Business> GetIndexServices(int? Index_Services_Id, int Index_Seo_Id)
        {
            IList<Index_Services_Business> ListObj = new List<Index_Services_Business>();
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                ListObj = db.ListIndexServices(Index_Services_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexServices(Index_Services Object)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexServices(int Index_Services_Id)
        {
            int Id = 0;
            try
            {
                Index_Services_Repository db = new Index_Services_Repository();
                Id = db.Delete(Index_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Index Slider
        public  int SaveIndexSlider(Index_Slider Object)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Slider_Business> GetIndexSlider(int? Index_Slider_Id, int Index_Seo_Id)
        {
            IList<Index_Slider_Business> ListObj = new List<Index_Slider_Business>();
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                ListObj = db.ListIndexSlider(Index_Slider_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexSlider(Index_Slider Object)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexSlider(int Index_Slider_Id)
        {
            int Id = 0;
            try
            {
                Index_Slider_Repository db = new Index_Slider_Repository();
                Id = db.Delete(Index_Slider_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Index Team
        public int SaveIndexTeam(Index_Team Object)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Index_Team_Business> GetIndexTeam(int? Index_Team_Id, int Index_Seo_Id)
        {
            IList<Index_Team_Business> ListObj = new List<Index_Team_Business>();
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                ListObj = db.ListIndexTeam(Index_Team_Id, Index_Seo_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateIndexTeam(Index_Team Object)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteIndexTeam(int Index_Team_Id)
        {
            int Id = 0;
            try
            {
                Index_Team_Repository db = new Index_Team_Repository();
                Id = db.Delete(Index_Team_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Knowledge Base Category

        public int SaveKnowledgeBaseCategory(Knowledge_Base_Category Object)
        {
            int Id = 0;

            try
            {
                Knowledge_Base_Category_Repository db = new Knowledge_Base_Category_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public IList<Knowledge_Base_Category> GetKnowledgeBaseCategory(int? Knowledge_Base_Category_Id, string Category_Url_Link)
        {
            IList<Knowledge_Base_Category> ListObj = new List<Knowledge_Base_Category>();
            try
            {
                Knowledge_Base_Category_Repository db = new Knowledge_Base_Category_Repository();
                ListObj = db.ListKnowledgeBaseCategory(Knowledge_Base_Category_Id, Category_Url_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeBaseCategory(Knowledge_Base_Category Object)
        {
            int Id = 0;

            try
            {
                Knowledge_Base_Category_Repository db = new Knowledge_Base_Category_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }
        public int DeleteKnowledgeBaseCategory(int Knowledge_Base_Category_Id)
        {
            int Id = 0;

            try
            {
                Knowledge_Base_Category_Repository db = new Knowledge_Base_Category_Repository();
                Id = db.Delete(Knowledge_Base_Category_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Id;
        }

        #endregion

        #region  Knowledge Base
        public int SaveKnowledgeBase(Knowledge_Base Object)
        {
            int Id = 0;
            try
            {
                Knowledge_Base_Repository db = new Knowledge_Base_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Knowledge_Base> GetKnowledgeBase(int? Knowledge_Base_Id  ,string Knowledge_Base_Url_Link)
        {
            IList<Knowledge_Base> ListObj = new List<Knowledge_Base>();
            try
            {
                Knowledge_Base_Repository db = new Knowledge_Base_Repository();
                ListObj = db.ListKnowledgeBase(Knowledge_Base_Id, Knowledge_Base_Url_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeBase(Knowledge_Base Object)
        {
            int Id = 0;
            try
            {
                Knowledge_Base_Repository db = new Knowledge_Base_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteKnowledgeBase(int Knowledge_Base_Id)
        {
            int Id = 0;
            try
            {
                Knowledge_Base_Repository db = new Knowledge_Base_Repository();
                Id = db.Delete(Knowledge_Base_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region  Knowledge Card
        public int SaveKnowledgeCard(Knowledge_Card Object)
        {
            int Id = 0;
            try
            {
                Knowledge_Card_Repository db = new Knowledge_Card_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Knowledge_Card_Business> GetKnowledgeCard(int? Knowledge_Card_Id, int? Knowledge_Base_Id)
        {
            IList<Knowledge_Card_Business> ListObj = new List<Knowledge_Card_Business>();
            try
            {
                Knowledge_Card_Repository db = new Knowledge_Card_Repository();
                ListObj = db.ListKnowledgeCard(Knowledge_Card_Id, Knowledge_Base_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeCard(Knowledge_Card Object)

        {
            int Id = 0;
            try
            {
                Knowledge_Card_Repository db = new Knowledge_Card_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteKnowledgeCard(int Knowledge_Card_Id)
        {
            int Id = 0;
            try
            {
                Knowledge_Card_Repository db = new Knowledge_Card_Repository();
                Id = db.Delete(Knowledge_Card_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region  Knowledge FailureMode
        public int SaveKnowledgeFailureMode(Knowledge_FailureMode Object)
        {
            int Id = 0;
            try
            {
                Knowledge_FailureMode_Repository db = new Knowledge_FailureMode_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Knowledge_FailureMode_Business> GetKnowledgeFailureMode(int? Knowledge_FailureMode_Id, int? Knowledge_Base_Id)
        {
            IList<Knowledge_FailureMode_Business> ListObj = new List<Knowledge_FailureMode_Business>();
            try
            {
                Knowledge_FailureMode_Repository db = new Knowledge_FailureMode_Repository();
                ListObj = db.ListknowledgeFailureMode(Knowledge_FailureMode_Id, Knowledge_Base_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeFailureMode(Knowledge_FailureMode Object)

        {
            int Id = 0;
            try
            {
                Knowledge_FailureMode_Repository db = new Knowledge_FailureMode_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteKnowledgeFailureMode(int Knowledge_FailureMode_Id)
        {
            int Id = 0;
            try
            {
                Knowledge_FailureMode_Repository db = new Knowledge_FailureMode_Repository();
                Id = db.Delete(Knowledge_FailureMode_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region  Knowledge RelatedSolution
        public int SaveKnowledgeRelatedSolution(Knowledge_RelatedSolution Object)
        {
            int Id = 0;
            try
            {
                Knowledge_RelatedSolution_Repository db = new Knowledge_RelatedSolution_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Knowledge_RelatedSolution_Business> GetKnowledgeRelatedSolution(int? Knowledge_RelatedSolution_Id, int? Knowledge_Base_Id)
        {
            IList<Knowledge_RelatedSolution_Business> ListObj = new List<Knowledge_RelatedSolution_Business>();
            try
            {
                Knowledge_RelatedSolution_Repository db = new Knowledge_RelatedSolution_Repository();
                ListObj = db.listknowledgeRelatedSolution(Knowledge_RelatedSolution_Id, Knowledge_Base_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeRelatedSolution(Knowledge_RelatedSolution Object)

        {
            int Id = 0;
            try
            {
                Knowledge_RelatedSolution_Repository db = new Knowledge_RelatedSolution_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteKnowledgeRelatedSolution(int Knowledge_RelatedSolution_Id)
        {
            int Id = 0;
            try
            {
                Knowledge_RelatedSolution_Repository db = new Knowledge_RelatedSolution_Repository();
                Id = db.Delete(Knowledge_RelatedSolution_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region  Knowledge WorkflowStep
        public int SaveKnowledgeWorkflowStep(Knowledge_WorkflowStep Object)
        {
            int Id = 0;
            try
            {
                Knowledge_WorkflowStep_Repository db = new Knowledge_WorkflowStep_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Knowledge_WorkflowStep_Business> GetKnowledgeWorkflowStep(int? Knowledge_WorkflowStep_Id, int? Knowledge_Base_Id)
        {
            IList<Knowledge_WorkflowStep_Business> ListObj = new List<Knowledge_WorkflowStep_Business>();
            try
            {
                Knowledge_WorkflowStep_Repository db = new Knowledge_WorkflowStep_Repository();
                ListObj = db.ListKnowledgeWorkflowStep(Knowledge_WorkflowStep_Id, Knowledge_Base_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateKnowledgeWorkflowStep(Knowledge_WorkflowStep Object)

        {
            int Id = 0;
            try
            {
                Knowledge_WorkflowStep_Repository db = new Knowledge_WorkflowStep_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteKnowledgeWorkflowStep(int Knowledge_WorkflowStep_Id)
        {
            int Id = 0;
            try
            {
                Knowledge_WorkflowStep_Repository db = new Knowledge_WorkflowStep_Repository();
                Id = db.Delete(Knowledge_WorkflowStep_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region  Engineering Services
        public int SaveEngineeringServices(Engineering_Services Object)
        {
            int Id = 0;
            try
            {

                Engineering_Services_Repository db = new Engineering_Services_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services> GetEngineeringServices(int? Engineering_Services_Id , string Engineering_Services_Url_Link)
        {
            IList<Engineering_Services> ListObj = new List<Engineering_Services> ();
            try
            {
                Engineering_Services_Repository db = new Engineering_Services_Repository();
                ListObj = db.ListEngineeringServices(Engineering_Services_Id, Engineering_Services_Url_Link);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServices(Engineering_Services Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Repository db = new Engineering_Services_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServices(int Engineering_Services_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Repository db = new Engineering_Services_Repository();
                Id = db.Delete(Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Engineering Services Features
        public int SaveEngineeringServicesFeatures(Engineering_Services_Features Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Features_Repository db = new Engineering_Services_Features_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services_Features> GetEngineeringServicesFeatures(int? Engineering_Services_Features_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_Features> ListObj = new List<Engineering_Services_Features>();
            try
            {
                Engineering_Services_Features_Repository db = new Engineering_Services_Features_Repository();
                ListObj = db.ListEngineeringServicesFeatures(Engineering_Services_Features_Id, Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServicesFeatures(Engineering_Services_Features Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Features_Repository db = new Engineering_Services_Features_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServicesFeatures(int Engineering_Services_Features_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Features_Repository db = new Engineering_Services_Features_Repository();
                Id = db.Delete(Engineering_Services_Features_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Engineering Services Applications
        public int SaveEngineeringServicesApplications(Engineering_Services_Applications Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Applications_Repository db = new Engineering_Services_Applications_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services_Applications> GetEngineeringServicesApplications(int? Engineering_Services_Applications_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_Applications> ListObj = new List<Engineering_Services_Applications>();
            try
            {
                Engineering_Services_Applications_Repository db = new Engineering_Services_Applications_Repository();
                ListObj = db.ListEngineeringServicesApplications(Engineering_Services_Applications_Id, Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServicesApplications(Engineering_Services_Applications Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Applications_Repository db = new Engineering_Services_Applications_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServicesApplications(int Engineering_Services_Applications_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Applications_Repository db = new Engineering_Services_Applications_Repository();
                Id = db.Delete(Engineering_Services_Applications_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Engineering Services Gallery
        public int SaveEngineeringServicesGallery(Engineering_Services_Gallery Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Gallery_Repository db = new Engineering_Services_Gallery_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services_Gallery> GetEngineeringServicesGallery(int? Engineering_Services_Gallery_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_Gallery> ListObj = new List<Engineering_Services_Gallery>();
            try
            {
                Engineering_Services_Gallery_Repository db = new Engineering_Services_Gallery_Repository();
                ListObj = db.ListEngineeringServicesGallery(Engineering_Services_Gallery_Id, Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServicesGallery(Engineering_Services_Gallery Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Gallery_Repository db = new Engineering_Services_Gallery_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServicesGallery(int Engineering_Services_Gallery_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Gallery_Repository db = new Engineering_Services_Gallery_Repository();
                Id = db.Delete(Engineering_Services_Gallery_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Engineering Services Tabs
        public int SaveEngineeringServicesTabs(Engineering_Services_Tabs Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Tabs_Repository db = new Engineering_Services_Tabs_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services_Tabs> GetEngineeringServicesTabs(int? Engineering_Services_Tabs_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_Tabs> ListObj = new List<Engineering_Services_Tabs>();
            try
            {
                Engineering_Services_Tabs_Repository db = new Engineering_Services_Tabs_Repository();
                ListObj = db.ListEngineeringServicesTabs(Engineering_Services_Tabs_Id, Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServicesTabs(Engineering_Services_Tabs Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Tabs_Repository db = new Engineering_Services_Tabs_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServicesTabs(int Engineering_Services_Tabs_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_Tabs_Repository db = new Engineering_Services_Tabs_Repository();
                Id = db.Delete(Engineering_Services_Tabs_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region Engineering Services SubTopic
        public int SaveEngineeringServicesSubTopic(Engineering_Services_SubTopic Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_SubTopic_Repository db = new Engineering_Services_SubTopic_Repository();
                Id = db.Add(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<Engineering_Services_SubTopic> GetEngineeringServicesSubTopic(int? Engineering_Services_SubTopic_Id, int? Engineering_Services_Id)
        {
            IList<Engineering_Services_SubTopic> ListObj = new List<Engineering_Services_SubTopic>();
            try
            {
                Engineering_Services_SubTopic_Repository db = new Engineering_Services_SubTopic_Repository();
                ListObj = db.ListEngineeringServicesSubTopic(Engineering_Services_SubTopic_Id, Engineering_Services_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateEngineeringServicesSubTopic(Engineering_Services_SubTopic Object)
        {
            int Id = 0;
            try
            {
                Engineering_Services_SubTopic_Repository db = new Engineering_Services_SubTopic_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngineeringServicesSubTopic(int Engineering_Services_SubTopic_Id)
        {
            int Id = 0;
            try
            {
                Engineering_Services_SubTopic_Repository db = new Engineering_Services_SubTopic_Repository();
                Id = db.Delete(Engineering_Services_SubTopic_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

        #region EngSer Gallery
        public int SaveEngSerGallery(EngSer_Gallery Object)
        {
            int Id = 0;
            try
            {
                EngSer_Gallery_Repository db = new EngSer_Gallery_Repository();
                Id = db.Add(Object);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<EngSer_Gallery> GetEngSerGallery(int? EngSer_Gallery_Id, int? Engineering_Services_Id)
        {
            IList<EngSer_Gallery> ListObj = new List<EngSer_Gallery>();
            try
            {
                EngSer_Gallery_Repository db = new EngSer_Gallery_Repository();
                ListObj = db.ListEngSerGallery(EngSer_Gallery_Id, Engineering_Services_Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }

        public int UpdateEngSerGallery(EngSer_Gallery Object)
        {
            int Id = 0;
            try
            {
                EngSer_Gallery_Repository db = new EngSer_Gallery_Repository();
                Id = db.Update(Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteEngSerGallery(int EngSer_Gallery_Id)
        {
            int Id = 0;
            try
            {
                EngSer_Gallery_Repository db = new EngSer_Gallery_Repository();
                Id = db.Delete(EngSer_Gallery_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        #endregion

    }
}
