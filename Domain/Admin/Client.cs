using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Client")]
    public class Client : Base
    {
        [Identifier("Client_Id")]
        public int Client_Id { get; set; }
        public string Client_Code { get; set; }
        public int FK_Product_Id { get; set; }
        public string Client_Name { get; set; }
        public string Client_Designation { get; set; }
        public string Company_Logo { get; set; }
        public string Company_Name { get; set; }
        public string Client_Text_Description { get; set; }
        public string Client_Video_Thumbnail { get; set; }
        public string Client_Video_Description { get; set; }

    }
}
