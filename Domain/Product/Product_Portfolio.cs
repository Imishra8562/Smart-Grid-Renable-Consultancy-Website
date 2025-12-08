using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Portfolio")]
    public  class Product_Portfolio : Base
    {
        [Identifier("Product_Portfolio_Id")]
        public int Product_Portfolio_Id { get; set; }
        public string Product_Portfolio_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Portfolio_Images { get; set; }
        public string Product_Portfolio_Decriptions { get; set; }

    }
}
