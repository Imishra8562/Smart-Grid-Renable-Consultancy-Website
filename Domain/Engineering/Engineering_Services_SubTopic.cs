using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Engineering_Services_SubTopic")]
    public class Engineering_Services_SubTopic :Base
    {
        [Identifier("Engineering_Services_SubTopic_Id")]
        public int Engineering_Services_SubTopic_Id { get; set; }
        public int FK_Engineering_Services_Id { get; set; }
        public string Engineering_Services_SubTopic_Name { get; set; }           // Load Flow Analysis
        public string Engineering_Services_SubTopic_Description { get; set; }
        public string Engineering_Services_SubTopic_IconClass { get; set; }      // bi bi-diagram-3
    }
}
