using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Header()
        {
            return PartialView("_Header");
        }
        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult TermAndCondition()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View(); 
        }
    }
}