using BusinessLayer;
using BusinessLayer.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Web.UI;
using Web.Areas.Admin.Model;

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
        [ChildActionOnly]
        public ActionResult Header()
        {
            MasterModel model = new MasterModel();
            IAdminManager adminManager = new AdminManager();
            IMasterManager MasterManager = new MasterManager();
            model.List_Industries_Obj = adminManager.GetIndustries(0, null);
            model.List_Engineering_Services_Obj = MasterManager.GetEngineeringServices(0, null);
            model.List_Knowledge_Base_Obj = MasterManager.GetKnowledgeBase(0, null);
            return PartialView("_Header", model);
        }


        public ActionResult Footer()
        {
            return PartialView("_Footer");
        }

        #endregion

        #region about
        [Route("about-us")]
        public ActionResult About()
        {
            return View();
        }
        [Route("our-team")]
        public ActionResult OurTeam()
        {
            return View();
        }
        [Route("company-overview")]
        public ActionResult Overview()
        {
            return View();
        }
        #endregion

        #region Industries 
        [Route("industries/{industries}")]
        public ActionResult IndustriesDetail(string industries)
        {
            AdminModel Model = new  AdminModel();
            IAdminManager AdminMangerobj = new AdminManager();
            Model.Industries_Obj = AdminMangerobj.GetIndustries(0, industries).FirstOrDefault();
            Model.List_Industries_Obj = AdminMangerobj.GetIndustries(0, null);
            return View(Model);
        }


        #endregion

        #region Knowledge Base
        [Route("knowledge-base/{url}")]
        public ActionResult KnowledgeBaseDetails(string url)
        {
            MasterModel Model = new MasterModel();
            IMasterManager manager = new MasterManager();
            Model.Knowledge_Base_Obj = manager.GetKnowledgeBase(0, url).FirstOrDefault();
            Model.List_Knowledge_Base_Obj = manager.GetKnowledgeBase(0, null);
            return View(Model);
        }

        #endregion

        #region EngineeringServices
        [Route("engineering-services/{url}")]
        public ActionResult EngineeringServicesDetails(string url)
        {
            MasterModel Model = new MasterModel();
            IMasterManager MasterManager = new MasterManager();
            Model.Engineering_Services_Obj = MasterManager.GetEngineeringServices(0, url).FirstOrDefault();
            Model.List_Engineering_Services_Obj = MasterManager.GetEngineeringServices(0, null);
            return View(Model);
        }
        #endregion

        #region news & insight
        [Route("newsroom")]
        public ActionResult Newsroom()
        {
            return View();
        }
        [Route("press-releases")]
        public ActionResult PressReleases()
        {
            return View();
        }
        [Route("insights")]
        public ActionResult Insights()
        {
            return View();
        }
        [Route("pulse-journal")]
        public ActionResult PulseJournal()
        {
            return View();
        }
        #endregion

        #region Training,Events & Careers
        [Route("training")]
        public ActionResult Training()
        {
            return View();
        }
        [Route("events")]
        public ActionResult Event()
        {
            return View();
        }
        [Route("courses")]
        public ActionResult Courses()
        {
            return View();
        }
        [Route("past-webinars")]
        public ActionResult PastWebinars()
        {
            return View();
        }
        [Route("careers")]
        public ActionResult Careers()
        {
            return View();
        }

        #endregion

        #region InvestorRelations & Sustainability
        [Route("investor-relations")]
        public ActionResult InvestorRelations()
        {
            return View();
        }
        [Route("sustainability")]
        public ActionResult Sustainability()
        {
            return View();
        }
        #endregion

        #region ContactUs & TermAndCondition
        [Route("contact-us")]
        public ActionResult ContactUs()
        {
            return View();
        }

        [Route("terms-and-conditions")]
        public ActionResult TermAndCondition()
        {
            return View();
        }
        #endregion

        #region login & register
        [Route("login")]
        public ActionResult Login()
        {
            return View();
        }
        #endregion

        #region Upload Image By Ck Editer
        public ActionResult UploadImage(HttpPostedFileBase upload)
        {
            try
            {
                if (upload != null && upload.ContentLength > 0)
                {
                    // Generate a random blog code
                    Random rnd = new Random();
                    int code = rnd.Next(1000000, 9999999);
                    string CkEditerCode = "CKEC-" + code.ToString();

                    // Define the upload directory
                    string uploadPath = Server.MapPath("~/Upload/editor-image/");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Count existing files with the same blog code
                    int no = 0;
                    string[] files = Directory.GetFiles(uploadPath, CkEditerCode + "*");
                    no = files.Length;

                    // Get file extension and save the file with a unique name
                    string extension = Path.GetExtension(upload.FileName);
                    string fileName = CkEditerCode + "_" + no + extension;
                    string filePath = Path.Combine(uploadPath, fileName);

                    upload.SaveAs(filePath);

                    // Generate image URL
                    string imageUrl = Url.Content("~/Upload/editor-image/" + fileName);

                    return Json(new
                    {
                        uploaded = true,
                        url = imageUrl
                    });
                }
                else
                {
                    return Json(new
                    {
                        uploaded = false,
                        error = new { message = "Upload failed: No file received." }
                    });
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    uploaded = false,
                    error = new { message = "Upload failed: " + ex.Message }
                });
            }
        }

        #endregion

    }
}