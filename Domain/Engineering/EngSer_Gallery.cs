using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_EngSer_Gallery")]
    public class EngSer_Gallery : Base
    {
        [Identifier("EngSer_Gallery_Id")]
        public int EngSer_Gallery_Id { get; set; }
        public string EngSer_Gallery_Code { get; set; }
        public int FK_Engeinering_Services_Id { get; set; }
        public string EngSer_Gallery_Title { get; set; }
        public string EngSer_Gallery_Description { get; set; }
        public string EngSer_Gallery_Image_Url { get; set; }

    }
}
