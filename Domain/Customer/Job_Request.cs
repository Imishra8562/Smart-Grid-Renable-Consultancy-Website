using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Job_Request")]
    public class Job_Request : Base
    {
        [Identifier("Job_Request_Id")]
        public int Job_Request_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Upload_Resume { get; set; }
        public string Job_Position { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

    }
}
