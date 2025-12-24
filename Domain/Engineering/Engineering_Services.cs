using System;
using System.Collections.Generic;

namespace Domain
{
    [Table("tbl_Engineering_Services")]
    public class Engineering_Services : Base
    {
        [Identifier("Engineering_Services_Id")]
        public int Engineering_Services_Id { get; set; }
        public string Engineering_Services_Code { get; set; }
        public string Engineering_Services_Name { get; set; }
        public string Engineering_Services_Page_Title { get; set; }
        public string Engineering_Services_Meta_Keyword { get; set; }
        public string Engineering_Services_Meta_Description { get; set; }
        public string Engineering_Services_News_Keyword { get; set; }
        public string Engineering_Services_News_Description { get; set; }
        public string Engineering_Services_Og_Image { get; set; }
        public string Engineering_Services_Og_Title { get; set; }
        public string Engineering_Services_Og_Description { get; set; }
        public string Engineering_Services_Image { get; set; }
        public string Engineering_Services_Image_Alt_Tag { get; set; }
        public string Engineering_Services_Description { get; set; }
        public string Engineering_Services_Url_Link { get; set; }

    }
}
