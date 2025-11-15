using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Index_Services")]
    public class Index_Services:Base
    {
        [Identifier("Index_Services_Id")]
        public int Index_Services_Id { get; set; }
        public int Fk_Index_Seo_Id { get; set; }
        public string Index_Services_Code { get; set; }
        public string Index_Services_Icon { get; set; }
        public string Index_Services_Title { get; set; }
        public string Index_Services_Description { get; set; }

    }
}
