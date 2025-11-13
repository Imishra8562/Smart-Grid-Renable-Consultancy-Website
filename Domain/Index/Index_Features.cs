using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Index_Features")]
    class Index_Features : Base
    {
        [Identifier("Index_Features_Id")]
        public int Index_Features_Id { get; set; }
        public String Index_Features_Code { get; set; }
        public string Index_Features_Image { get; set; }
        public string Index_Features_Title { get; set; }
        public string Index_Features_Headline1 { get; set; }
        public string Index_Features_SubHeadline1 { get; set; }
        public string Index_Features_Headline2 { get; set; }
        public string Index_Features_SubHeadline2 { get; set; }
        public string Index_Features_Headline3 { get; set; }
        public string Index_Features_SubHeadline3 { get; set; }

    }
}
