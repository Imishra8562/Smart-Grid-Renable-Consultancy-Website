using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Image")]
    public class Product_Image : Base
    {
        [Identifier("Product_Image_Id")]
        public int Product_Image_Id { get; set; }
        public string Product_Image_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Details_Image { get; set; }
        public string Product_Details_Decriptions { get; set; }

    }
}
