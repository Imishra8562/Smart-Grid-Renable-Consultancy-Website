using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Features")]
    public class Product_Features : Base    {
        [Identifier("Product_Features_Id")]
        public int Product_Features_Id { get; set; }
        public string Product_Features_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Features_Name { get; set; }
        public string Product_Features_Images { get; set; }
        public string Product_Features_Decriptions { get; set; }

    }
}
