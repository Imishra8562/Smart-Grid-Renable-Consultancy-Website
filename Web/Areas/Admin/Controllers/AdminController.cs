using BusinessLayer;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Model;
using Web.Controllers;

namespace Web.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        #region utilities

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
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
        #endregion

        #region Header & Layout

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
        #endregion

        #region EmployeeDashboar
        public ActionResult EmployeeDashboard()
        {
            return View();
        }
        #endregion

        #region Index Seo
        public ActionResult IndexSeo(int? Index_Seo_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);
            if (Index_Seo_Id.HasValue)
            {
                Model.Index_Seo_Obj = Manager.GetIndexSeo(Index_Seo_Id, null).FirstOrDefault();
            }

            return View(Model);
        }

        #endregion
    }
}
