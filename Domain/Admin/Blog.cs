using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Blog")]
    public class Blog : Base
    {
        [Identifier("Blog_Id")]
        public int Blog_Id { get; set; }
        public int FK_Blog_Category_Id { get; set; }
        public string Blog_Code { get; set; }
        public string Page_Title { get; set; }
        public string Meta_Keyword { get; set; }
        public string Meta_Description { get; set; }  
        public string News_Keyword { get; set; }
        public string News_Description { get; set; }
        public string Og_Title { get; set; }
        public string Og_Description { get; set; }
        public string Meta_Og_Image { get; set; }
        public string Blog_Image { get; set; }
        public string Meta_Alt_tag { get; set; }
        public string Blog_Heading { get; set; }
        public string Blog_Description { get; set; }
        public string Blog_Link { get; set; }

    }
}
