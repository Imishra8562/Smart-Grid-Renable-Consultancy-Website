using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Engineering_Services_Tabs")]
    public class Engineering_Services_Tabs : Base
    {
        [Identifier("Engineering_Services_Tab_Id")]
        public int Engineering_Services_Tab_Id { get; set; }
        public int FK_Engineering_Services_Id { get; set; }
        public string Engineering_Services_Title { get; set; }        // Short Circuit Study
        public string Engineering_Services_Content { get; set; }      // HTML content
    }
}
