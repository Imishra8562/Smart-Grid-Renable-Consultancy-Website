using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Index_Slider")]
    class Index_Slider:Base
    {
        [Identifier("Index_Slider_Id")]
        public int Index_Slider_Id { get; set; }
        public String Index_Slider_Code { get; set; }
        public string Index_Slider_Image { get; set; }
        public string Index_Slider_Alt_Tag { get; set; }
        public string Index_Slider_Headline { get; set; }
        public string Index_Slider_SubHeadline { get; set; }
    }
}
