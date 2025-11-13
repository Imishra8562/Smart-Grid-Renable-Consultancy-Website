using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    
   [Table("tbl_Index_Seo")]
   public class Index_Seo : Base
   {
       [Identifier("Index_Seo_Id")]
       public int Index_Seo_Id { get; set; }
       public string Index_Seo_Code { get; set; }
       public string Index_Seo_Page_Title { get; set; }
       public string Index_Seo_Meta_Keyword { get; set; }
       public string Index_Seo_Meta_Description { get; set; }
       public string Index_Seo_Og_Image { get; set; }
       public string Index_Seo_Image_Alt_Tag { get; set; }
       public string Index_Seo_Og_Title { get; set; }
       public string Index_Seo_Og_Description { get; set; }
       public string Index_Seo_Slug { get; set; }

    }
}
