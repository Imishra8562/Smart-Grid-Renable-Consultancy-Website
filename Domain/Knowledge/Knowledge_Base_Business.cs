using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Knowledge_Base_Business :Knowledge_Base
    {
        public string Category_Name { get; set; }
        public string Category_Description { get; set; }
        public string Category_Url_Link { get; set; }
    }
}
