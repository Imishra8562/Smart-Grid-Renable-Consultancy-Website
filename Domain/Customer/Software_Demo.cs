using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    [Table("tbl_Software_Demo")]
    public class Software_Demo : Base
    {
        [Identifier("Software_Demo_Id")]
        public int Software_Demo_Id { get; set; }
        public string Software_Demo_Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Software { get; set; }
        public string Message { get; set; }
        public string Team_Size { get; set; }
        public string Software_Requirement_Time { get; set; }
        public string Organization_Name { get; set; }
        public string Monthly_Loan { get; set; }
        public string MLM_Plan { get; set; }
        public string Loan_Type { get; set; }
        public string Currently_Using { get; set; }
        public string Manage_your_leads { get; set; }
        public string City_Name { get; set; }
        public bool Is_Quick_Apply { get; set; }
        public bool Is_Landing_Page { get; set; }
        public bool Is_Follow_Up_Closed { get; set; }

        // New Additions for your extended form:
        public bool Has_Website { get; set; }

        public string Website_URL { get; set; }

        public string Website_Service_Type { get; set; } 

        public bool Has_EWebsite_Site { get; set; }

        public string EWebsite_Site_URL { get; set; }

        public string EWebsite_Service_Type { get; set; } 
        public string B2B_Name { get; set; } 
        public string B2B_Describe { get; set; } 
        public string B2C_Name { get; set; }
        public string B2C_Describe { get; set; }
        public string Required_Portal_Type { get; set; }
    }
}
