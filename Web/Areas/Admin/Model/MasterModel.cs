using Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Areas.Admin.Model
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
    }
}