using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Knowledge_RelatedSolution")]
   public  class Knowledge_RelatedSolution : Base
    {
        [Identifier("Knowledge_RelatedSolution_Id")]
        public int Knowledge_RelatedSolution_Id { get; set; }
        public int FK_Knowledge_Base_Id { get; set; }
        public string Knowledge_RelatedSolution_Code { get; set; }
        public string Knowledge_RelatedSolution_Name { get; set; }
        public string Knowledge_RelatedSolution_Title { get; set; }
        public string Knowledge_RelatedSolution_Image { get; set; }
        public string Knowledge_RelatedSolution_Image_Alt_Tag { get; set; }
        public string Knowledge_RelatedSolution_Description { get; set; }
    }
}
