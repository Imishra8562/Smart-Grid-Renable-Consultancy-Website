using System;
using System.Collections.Generic;

namespace Domain
{
    [Table("tbl_Knowledge_Base")]
    public class Knowledge_Base : Base
    {
        [Identifier("Knowledge_Base_Id")]
        public int Knowledge_Base_Id { get; set; }
        public int FK_Knowledge_Base_Category_Id { get; set; }
        public string Knowledge_Base_Code { get; set; }
        public string Knowledge_Base_Name { get; set; }
        public string Knowledge_Base_Page_Title { get; set; }
        public string Knowledge_Base_Meta_Keyword { get; set; }
        public string Knowledge_Base_Meta_Description { get; set; }
        public string Knowledge_Base_News_Keyword { get; set; }
        public string Knowledge_Base_News_Description { get; set; }
        public string Knowledge_Base_Og_Image { get; set; }
        public string Knowledge_Base_Og_Title { get; set; }
        public string Knowledge_Base_Og_Description { get; set; }
        public string Knowledge_Base_Image { get; set; }
        public string Knowledge_Base_Image_Alt_Tag { get; set; }
        public string Knowledge_Base_Description { get; set; }
        public string Knowledge_Base_Url_Link { get; set; }

    }
}
