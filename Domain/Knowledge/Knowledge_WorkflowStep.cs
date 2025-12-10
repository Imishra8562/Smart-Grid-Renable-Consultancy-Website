using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Knowledge_WorkflowStep")]
    public class Knowledge_WorkflowStep
    {
        [Identifier("Knowledge_WorkflowStep_Id")]
        public int Knowledge_WorkflowStep_Id { get; set; }
        public int FK_Knowledge_Base_Id { get; set; }
        public string Knowledge_WorkflowStep_Code { get; set; }
        public string Knowledge_WorkflowStep_Name { get; set; }
        public string Knowledge_WorkflowStep_Title { get; set; }
        public string Knowledge_WorkflowStep_Image { get; set; }
        public string Knowledge_WorkflowStep_Image_Alt_Tag { get; set; }
        public string Knowledge_WorkflowStep_Description { get; set; }
    }
}
