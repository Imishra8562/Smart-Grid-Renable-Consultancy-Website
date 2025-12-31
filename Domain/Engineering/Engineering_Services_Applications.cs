using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Engineering_Services_Applications")]
    public class Engineering_Services_Applications : Base
    {
        [Identifier("Engineering_Services_Applications_Id")]
        public int Engineering_Services_Applications_Id { get; set; }
        public int FK_Engineering_Services_Id { get; set; }
        public string Engineering_Services_Applications_Name { get; set; }
        public string Engineering_Services_Applications_Description { get; set; }
        public string Engineering_Services_Applications_IconClass { get; set; }
    }
}
