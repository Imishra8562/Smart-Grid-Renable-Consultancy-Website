using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Demo_Follow_Up")]
    public class Demo_Follow_Up : Base
    {
        [Identifier("Demo_Follow_Up_Id")]
        public int Demo_Follow_Up_Id { get; set; }
        public string Demo_Follow_Up_Code { get; set; }
        public int FK_Software_Demo_Id { get; set; }
        public string Demo_Follow_Up_By { get; set; }
        public string Query_Response { get; set; }
        public DateTime? Next_Follow_Date { get; set; }
        public DateTime? Next_Follow_Time { get; set; }
        public string Description { get; set; }

    }
}
