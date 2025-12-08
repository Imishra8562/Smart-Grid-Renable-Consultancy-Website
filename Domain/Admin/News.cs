using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_News")]
    public class News : Base
    {
        [Identifier("News_Id")]
        public int News_Id { get; set; }
        public string News_Code { get; set; }
        public string News_Image { get; set; }
        public string News_Description { get; set; }

    }
}
