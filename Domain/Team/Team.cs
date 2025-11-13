using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    [Table("tbl_Team")]
    class Team :Base
    {
        [Identifier("Team_Id")]
        public int Team_Id { get; set; }
        public String Team_Member_Name { get; set; }
        public string Team_Member_Designation { get; set; }
        public string Team_Member_Image { get; set; }
        public string Team_Member_Facebook_Url { get; set; }
        public string Team_Member_Twitter_Url { get; set; }
        public string Team_Member_Linkedin_Url { get; set; }
        public string Team_Member_Instagram_Url { get; set; }
    }
}
