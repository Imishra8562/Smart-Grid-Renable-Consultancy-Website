using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Blog_FAQ")]
    public class Blog_FAQ : Base
    {
        [Identifier("Blog_FAQ_Id")]
        public int Blog_FAQ_Id { get; set; }
        public string Blog_FAQ_Code { get; set; }
        public int FK_Blog_Id { get; set; }
        public string Blog_FAQ_Question { get; set; }
        public string Blog_FAQ_Answer { get; set; }
    }
}
