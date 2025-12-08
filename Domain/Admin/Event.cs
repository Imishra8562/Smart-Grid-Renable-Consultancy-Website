using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Event")]
    public class Event : Base
    {
        [Identifier("Event_Id")]
        public int Event_Id { get; set; }
        public string Event_Name { get; set; }
        public string Description { get; set; }
        public bool Active_Button { get; set; }
        public string Button_Url { get; set; }

    }
}
