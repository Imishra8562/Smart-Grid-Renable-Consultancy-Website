using BusinessLayer;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        #region Layout & Home
        public ActionResult Index()
        {
            MasterModel Model = new MasterModel();
            IMasterManager MasterManager = new MasterManager();
            Model.Index_Seo_Obj = MasterManager.GetIndexSeo(0, null).FirstOrDefault();
            Model.List_Index_Features_Business_Obj = MasterManager.GetIndexFeatures(0, 0);
            Model.List_Index_Services_Business_Obj = MasterManager.GetIndexServices(0, 0);
            Model.List_Index_Slider_Business_Obj = MasterManager.GetIndexSlider(0, 0);
            Model.List_Index_Team_Business_Obj = MasterManager.GetIndexTeam(0, 0);
            return View(Model);
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
        public ActionResult Event()
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
        #region industry
        public ActionResult Industry()
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