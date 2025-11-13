using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        #region Layout & Home
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

        #endregion

        #region about
        public ActionResult About()
        {
            return View();
        }
        public ActionResult OurTeam()
        {
            return View();
        }
        public ActionResult Overview()
        {
            return View();
        }
        #endregion

        #region Industries
        public ActionResult Industries()
        {
            return View();
        }
        #endregion

        #region news & insight
        public ActionResult Newsroom()
        {
            return View();
        }
        public ActionResult PressReleases()
        {
            return View();
        }
        public ActionResult Insights()
        {
            return View();
        }
        public ActionResult PulseJournal()
        {
            return View();
        }
        #endregion

        #region Training,Events & Careers
        public ActionResult Training()
        {
            return View();
        }
        public ActionResult Events()
        {
            return View();
        }
        public ActionResult Courses()
        {
            return View();
        }
        public ActionResult PastWebinars()
        {
            return View();
        }
       
        public ActionResult Careers()
        {
            return View();
        }

        #endregion

        #region KnowledgeBase
        public ActionResult KnowledgeBase()
        {
            return View();
        }
        #endregion

        #region EngineeringServices
        public ActionResult EngineeringServices()
        {
            return View();
        }
        #endregion

        #region InvestorRelations & Sustainability
        public ActionResult InvestorRelations()
        {
            return View();
        }
        public ActionResult Sustainability()
        {
            return View();
        }
        #endregion

        #region ContactUs & TermAndCondition
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult TermAndCondition()
        {
            return View();
        }
        #endregion

        #region login & register
        public ActionResult Login()
        {
            return View();
        }
        #endregion

    }
}