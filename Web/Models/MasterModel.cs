using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
	public class MasterModel
	{

        #region Index Seo
        public HttpPostedFileBase Index_Seo_Og_Image { get; set; }
        public Index_Seo Index_Seo_Obj { get; set; }
        public IList<Index_Seo> List_Index_Seo_Obj { get; set; }
        #endregion

        #region Index Features
        public HttpPostedFileBase Index_Features_Image { get; set; }
        public Index_Features Index_Features_Obj { get; set; }
        public Index_Features_Business Index_Features_Business_Obj { get; set; }
        public IList<Index_Features> List_Index_Features_Obj { get; set; }
        public IList<Index_Features_Business> List_Index_Features_Business_Obj { get; set; }
        #endregion

        #region Index Services
        public HttpPostedFileBase Index_Services_Icon { get; set; }
        public Index_Services Index_Services_Obj { get; set; }
        public Index_Services_Business Index_Services_Business_Obj { get; set; }
        public IList<Index_Services_Business> List_Index_Services_Business_Obj { get; set; }
        #endregion

        #region Index Slider 
        public HttpPostedFileBase Index_Slider_Image { get; set; }
        public Index_Slider Index_Slider_Obj { get; set; }
        public Index_Slider_Business Index_Slider_Business_Obj { get; set; }
        public IList<Index_Slider_Business> List_Index_Slider_Business_Obj { get; set; }
        #endregion

        #region Index Team
        public HttpPostedFileBase Index_Team_Member_Image { get; set; }
        public Index_Team Index_Team_Obj { get; set; }
        public Index_Team_Business Index_Team_Business_Obj { get; set; }
        public IList<Index_Team_Business> List_Index_Team_Business_Obj { get; set; }
        #endregion

        #region Industries

        public HttpPostedFileBase Industries_Image { get; set; }
        public HttpPostedFileBase Industries_Og_Image { get; set; }
        public Industries Industries_Obj { get; set; }
        public IList<Industries> List_Industries_Obj { get; set; }
        #endregion


        #region Knowledge Base Category
        public Knowledge_Base_Category Knowledge_Base_Category_Obj { get; set; }
        public IList<Knowledge_Base_Category> List_Knowledge_Base_Category_Obj { get; set; }

        #endregion

        #region Knowledge Base
        public HttpPostedFileBase Knowledge_Base_Og_Image { get; set; }
        public HttpPostedFileBase Knowledge_Base_Image { get; set; }
        public Knowledge_Base Knowledge_Base_Obj { get; set; }
        public IList<Knowledge_Base> List_Knowledge_Base_Obj { get; set; }
        public Knowledge_Base_Business Knowledge_Base_Business_Obj { get; set; }
        public IList<Knowledge_Base_Business> List_Knowledge_Base_Business_Obj { get; set; }
        #endregion

        #region Knowledge Card
        public HttpPostedFileBase Knowledge_Card_Og_Image { get; set; }
        public HttpPostedFileBase Knowledge_Card_Image { get; set; }
        public Knowledge_Card Knowledge_Card_Obj { get; set; }
        public Knowledge_Card_Business Knowledge_Card_Business_Obj { get; set; }
        public IList<Knowledge_Card> List_Knowledge_Card_Obj { get; set; }
        public IList<Knowledge_Card_Business> List_Knowledge_Card_Business_Obj { get; set; }

        #endregion

        #region Knowledge FailureMode
        public HttpPostedFileBase Knowledge_FailureMode_Og_Image { get; set; }
        public HttpPostedFileBase Knowledge_FailureMode_Image { get; set; }
        public Knowledge_FailureMode Knowledge_FailureMode_Obj { get; set; }
        public Knowledge_FailureMode_Business Knowledge_FailureMode_Business_Obj { get; set; }
        public IList<Knowledge_FailureMode> List_Knowledge_FailureMode_Obj { get; set; }
        public IList<Knowledge_FailureMode_Business> List_Knowledge_FailureMode_Business_Obj { get; set; }
        #endregion

        #region Knowledge RelatedSolution
        public HttpPostedFileBase Knowledge_RelatedSolution_Og_Image { get; set; }
        public HttpPostedFileBase Knowledge_RelatedSolution_Image { get; set; }
        public Knowledge_RelatedSolution Knowledge_RelatedSolution_Obj { get; set; }
        public Knowledge_RelatedSolution_Business Knowledge_RelatedSolution_Business_Obj { get; set; }
        public IList<Knowledge_RelatedSolution> List_Knowledge_RelatedSolution_Obj { get; set; }
        public IList<Knowledge_RelatedSolution_Business> List_Knowledge_RelatedSolution_Business_Obj { get; set; }
        #endregion

        #region Knowledge WorkflowStep
        public HttpPostedFileBase Knowledge_WorkflowStep_Og_Image { get; set; }
        public HttpPostedFileBase Knowledge_WorkflowStep_Image { get; set; }
        public Knowledge_FailureMode Knowledge_WorkflowStep_Obj { get; set; }
        public Knowledge_WorkflowStep_Business Knowledge_WorkflowStep_Business_Obj { get; set; }
        public IList<Knowledge_WorkflowStep> List_Knowledge_WorkflowStep_Obj { get; set; }
        public IList<Knowledge_WorkflowStep_Business> List_Knowledge_WorkflowStep_Business_Obj { get; set; }
        #endregion

    }
}