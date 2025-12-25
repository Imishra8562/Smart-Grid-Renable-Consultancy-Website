using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Engineering_Services_Features")]
    public class Engineering_Services_Features :Base
    {
        [Identifier("Engineering_Services_Features_Id")]
        public int Engineering_Services_Features_Id { get; set; }
      //  public string Engineering_Services_Feature_Code { get; set; }    
        public int FK_Engineering_Services_Id { get; set; }
        public string Engineering_Services_Features_Name { get; set; }
        public string Engineering_Services_Features_Description { get; set; }
        public string Engineering_Services_Features_IconClass { get; set; }
    }
}
