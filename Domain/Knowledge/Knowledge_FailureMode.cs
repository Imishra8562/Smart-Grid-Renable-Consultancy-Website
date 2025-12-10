using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Knowledge_FailureMode")]
   public class Knowledge_FailureMode : Base
    {
        [Identifier("Knowledge_FailureMode_Id")]
        public int Knowledge_FailureMode_Id { get; set; }
        public int FK_Knowledge_Base_Id { get; set; }
        public string Knowledge_FailureMode_Code { get; set; }
        public string Knowledge_FailureMode_Name { get; set; }
        public string Knowledge_FailureMode_Title { get; set; }
        public string Knowledge_FailureMode_Image { get; set; }
        public string Knowledge_FailureMode_Image_Alt_Tag { get; set; }
        public string Knowledge_FailureMode_Description { get; set; }

    }
}
