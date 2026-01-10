using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Career_Category")]
    public class Career_Category : Base
    {
        [Identifier("Career_Category_Id")]
        public int Career_Category_Id { get; set; }
        public string Career_Category_Title { get; set; }
        public string Career_Category_Code { get; set; }
        public string Career_Category_Image { get; set; }
        public string Career_Category_Description { get; set; }
    }
}
