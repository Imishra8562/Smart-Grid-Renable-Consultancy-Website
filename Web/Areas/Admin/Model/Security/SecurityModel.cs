using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class SecurityModel
    {
        public User User_Obj { get; set; }
        public User_Business User_Business_Obj { get; set; }
        public IList<User_Business> List_User_Obj { get; set; }

        public string Password { get; set; }
        public User_Role User_Role_Obj { get; set; }
        public IList<User_Role> List_User_Role_Obj { get; set; }
    }
}