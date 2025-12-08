using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Product_FAQ")]
    public class Product_FAQ : Base
    {
        [Identifier("Product_FAQ_Id")]
        public int Product_FAQ_Id { get; set; }
        public string Product_FAQ_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Product_FAQ_Question { get; set; }
        public string Product_FAQ_Answer { get; set; }
    }
}
