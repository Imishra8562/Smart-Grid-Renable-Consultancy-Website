using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Blog_Comment_Business : Blog_Comment
    {
        public int FK_Blog_Category_Id { get; set; }
        public string Meta_alt_tag { get; set; }
        public string Meta_Description { get; set; }
        public string Meta_Keyword { get; set; }
        public string Meta_Og_Image { get; set; }
        public string Blog_Heading { get; set; }
        public string Blog_Image { get; set; }
        public string Blog_Description { get; set; }
        public string Blog_Link { get; set; }


        public string Status_Name { get; set; }
        public string Status_Description { get; set; }
    }
}
