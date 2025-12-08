using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Benefits")]
    public  class Product_Benefits : Base
    {
        [Identifier("Product_Benefits_Id")]
        public int Product_Benefits_Id { get; set; }
        public string Product_Benefits_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Benefits_Name { get; set; }
        public string Product_Benefits_Images { get; set; }
        public string Product_Benefits_Decriptions { get; set; }


    }
}
