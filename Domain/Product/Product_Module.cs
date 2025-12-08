using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_Module")]
    public class Product_Module : Base
    {
        [Identifier("Product_Module_Id")]
        public int Product_Module_Id { get; set; }
        public string Product_Module_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_Module_Name { get; set; }
        public string Product_Module_Images { get; set; }
        public string Product_Module_Decriptions { get; set; }
    }
}
