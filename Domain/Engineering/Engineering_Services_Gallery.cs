using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Engineering_Services_Gallery")]
    public class Engineering_Services_Gallery :Base
    {
        [Identifier("Engineering_Services_Gallery_Image_Id")]
        public int FK_Engineering_Services_Id { get; set; }
        public int Engineering_Services_Gallery_Image_Id { get; set; }
        public string Engineering_Services_Gallery_Image { get; set; }
        public string Engineering_Services_Gallery_Image_Code { get; set; }
        public string Engineering_Services_Gallery_AltText { get; set; }
    }
}
