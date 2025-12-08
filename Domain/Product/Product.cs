using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Product")]
    public class Product : Base
    {
        [Identifier("Product_Id")]
        public int Product_Id { get; set; }
        public string Product_Code { get; set; }
        public int FK_Industries_Id { get; set; }
        public string Product_Name { get; set; }
        public string Product_Page_Title { get; set; }
        public string Product_Meta_Keyword { get; set; }
        public string Product_Meta_Description { get; set; }
        public string Product_News_Keyword { get; set; }
        public string Product_News_Description { get; set; }
        public string Product_Og_Image { get; set; }
        public string Product_Og_Title { get; set; }
        public string Product_Og_Description { get; set; }
        public string Product_Image { get; set; }
        public string Product_Image_Alt_Tag { get; set; }
        public string Product_Description { get; set; }
        public string Product_Rating { get; set; }
        public string Product_Review_Count { get; set; }  
        public string Product_Url_Link { get; set; }

    }
}
