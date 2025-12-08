using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Demo_Follow_Up_Business : Demo_Follow_Up
    {
        public string Software_Demo_Code { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone_No { get; set; }
        public string Software { get; set; }
        public string Message { get; set; }
        public bool Is_Follow_Up_Closed { get; set; }
    }
}
