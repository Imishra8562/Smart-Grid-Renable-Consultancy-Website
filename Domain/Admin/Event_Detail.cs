using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Event_Detail")]
    public class Event_Detail : Base
    {
        [Identifier("Event_Detail_Id")]
        public int Event_Detail_Id { get; set; }
        public int FK_Event_Id { get; set; }
        public string Event_Code { get; set; }
        public string Event_Image { get; set; }
        public string Description { get; set; }

    }
}
