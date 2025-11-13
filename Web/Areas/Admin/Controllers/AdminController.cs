using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        #region Get System IP
        public string SystemIP()
        {
            string Ipaddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(Ipaddress))
            {
                Ipaddress = Request.ServerVariables["REMOTE_ADDR"];
            }
            return Ipaddress;
        }

        #endregion
        #region Header
        public ActionResult Header()
        {
            return PartialView("_Header");
        }
        #endregion

        #region Menu
        public ActionResult Menu()
        {
            return PartialView("_Menu");
        }
        #endregion

        #region Footer
        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }
        #endregion
        #region Footer
        public ActionResult EmployeeDashboard()
        {
            return View();
        }
        #endregion
    }
}
