using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Knowledge_Card")]
    public class Knowledge_Card :Base
    {
        [Identifier("Knowledge_Card_Id")]
        public int Knowledge_Card_Id { get; set; }
        public int FK_Knowledge_Base_Id { get; set; }
        public string Knowledge_Card_Code { get; set; }
        public string Knowledge_Card_Name { get; set; }
        public string Knowledge_Card_Title { get; set; }
        public string Knowledge_Card_Image { get; set; }
        public string Knowledge_Card_Image_Alt_Tag { get; set; }
        public string Knowledge_Card_Description { get; set; }

    }
}
