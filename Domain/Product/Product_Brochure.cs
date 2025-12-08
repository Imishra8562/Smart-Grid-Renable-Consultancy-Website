using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Brochure")]
    public class Product_Brochure : Base
    {
        [Identifier("Product_Brochure_Id")]
        public int Product_Brochure_Id { get; set; }
        public string Product_Brochure_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Brochure_File { get; set; }
        public string Product_Brochure_Decriptions { get; set; }
    }
}
