using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Index_Team")]
    public class Index_Team : Base
    {
        [Identifier("Index_Team_Id")]
        public int Index_Team_Id { get; set; }
        public int Fk_Index_Seo_Id { get; set; }
        public string Index_Team_Member_Name { get; set; }
        public string Index_Team_Member_Designation { get; set; }
        public string Index_Team_Member_Image { get; set; }
        public string Index_Team_Member_Facebook_Url { get; set; }
        public string Index_Team_Member_Twitter_Url { get; set; }
        public string Index_Team_Member_Linkedin_Url { get; set; }
        public string Index_Team_Member_Instagram_Url { get; set; }
    }
}
