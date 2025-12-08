using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Contact")]
    public class Contact : Base
    {
        [Identifier("Contact_Id")]
        public int Contact_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Website { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public string Review { get; set; }

    }
}
