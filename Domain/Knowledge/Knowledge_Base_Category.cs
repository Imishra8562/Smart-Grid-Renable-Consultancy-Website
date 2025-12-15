using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Knowledge_Base_Category")]

    public class Knowledge_Base_Category :Base
    {
        [Identifier("Knowledge_Base_Category_Id")]
        public int Knowledge_Base_Category_Id { get; set; }
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public string Category_Url_Link { get; set; }

    }
}
