using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Industries")]
    public class Industries : Base
    {
        [Identifier("Industries_Id")]
        public int Industries_Id { get; set; }
        public string Industries_Code { get; set; }
        public string Industries_Name { get; set; }
        public string Industries_Page_Title { get; set; }
        public string Industries_Meta_Keyword { get; set; }
        public string Industries_Meta_Description { get; set; }
        public string Industries_News_Keyword { get; set; }
        public string Industries_News_Description { get; set; }
        public string Industries_Og_Image { get; set; }
        public string Industries_Og_Title { get; set; }
        public string Industries_Og_Description { get; set; }
        public string Industries_Image { get; set; }
        public string Industries_Image_Alt_Tag { get; set; }
        public string Industries_Description { get; set; }
        public string Industries_Url_Link { get; set; }

    }
}
