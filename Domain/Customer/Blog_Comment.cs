using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Blog_Comment")]
    public class Blog_Comment : Base
    {
        [Identifier("Blog_Comment_Id")]
        public int Blog_Comment_Id { get; set; }
        public int FK_Blog_Id { get; set; }
        public int FK_Status_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Message { get; set; }
        public string Description { get; set; }

    }
}
