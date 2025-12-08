using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Partner")]
    public class Partner : Base
    {
        [Identifier("Partner_Id")]
        public int Partner_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Website { get; set; }
        public string Upload_File { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Review { get; set; }

    }
}
