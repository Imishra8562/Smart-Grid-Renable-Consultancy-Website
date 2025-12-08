using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
   
    [Table("tbl_Blog_Category")]
    public class Blog_Category : Base
    {
        [Identifier("Blog_Category_Id")]
        public int Blog_Category_Id { get; set; }
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }

    }
}
