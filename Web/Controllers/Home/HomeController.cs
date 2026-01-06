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
        public ActionResult Industry()
        {
             AdminModel Model = new  AdminModel();
            IAdminManager AdminMangerobj = new AdminManager();
            Model.List_Industries_Obj = AdminMangerobj.GetIndustries(0, null);
            return View(Model);
        }
        [Route("industries/{industries}")]
        public ActionResult IndustriesDetail(string industries)
        {
            AdminModel Model = new  AdminModel();
            IAdminManager AdminMangerobj = new AdminManager();
            Model.Industries_Obj = AdminMangerobj.GetIndustries(0, industries).FirstOrDefault();
            Model.List_Industries_Obj = AdminMangerobj.GetIndustries(0, null);
            //Model.List_Product_Business_Obj = AdminMangerobj.GetProduct(0, 0, null).Where(x => x.Industries_Url_Link == industries).ToList();

            return View(Model);
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


        #region KnowledgeBase
        public ActionResult KnowledgeBase()
        {
            MasterModel Model = new MasterModel();
            IMasterManager MasterManager = new MasterManager();
            Model.List_Knowledge_Base_Business_Obj = MasterManager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_Base_Category_Obj = MasterManager.GetKnowledgeBaseCategory(0, null);
            return View(Model);
        }
        [Route("knowledge-base/{url}")]
        public ActionResult KnowledgeBaseDetails(string url)
        {
            MasterModel Model = new MasterModel();
            IMasterManager manager = new MasterManager();
            // Get Knowledge Base by URL
            Model.Knowledge_Base_Obj = manager .GetKnowledgeBase(0, 0, url).FirstOrDefault();
            int knowledgeBaseId = Model.Knowledge_Base_Obj.Knowledge_Base_Id;
            Model.List_Knowledge_Card_Business_Obj = manager.GetKnowledgeCard(0, knowledgeBaseId);
            Model.List_Knowledge_FailureMode_Business_Obj = manager.GetKnowledgeFailureMode(0, knowledgeBaseId);
            Model.List_Knowledge_RelatedSolution_Business_Obj = manager.GetKnowledgeRelatedSolution(0, knowledgeBaseId);
            Model.List_Knowledge_WorkflowStep_Business_Obj = manager.GetKnowledgeWorkflowStep(0, knowledgeBaseId);
            return View(Model);
        }

        #endregion

        #region EngineeringServices
        public ActionResult EngineeringServices()
        {
            MasterModel Model = new MasterModel();
            IMasterManager MasterManager = new MasterManager();
            Model.List_Engineering_Services_Obj = MasterManager.GetEngineeringServices(0, null);
            return View(Model);
        }
        public ActionResult EngineeringServiesDetails(string url)
        {
            MasterModel Model = new MasterModel();
            IMasterManager MasterManager = new MasterManager();
            Model.Engineering_Services_Obj = MasterManager.GetEngineeringServices(0, url).FirstOrDefault();
            Model.Engineering_Services_Tabs_Obj = MasterManager.GetEngineeringServicesTabs(0, null).FirstOrDefault();
            int EngSeId = Model.Engineering_Services_Obj.Engineering_Services_Id;
            Model.List_Engineering_Services_Applications_Obj = MasterManager.GetEngineeringServicesApplications(null, EngSeId);
            Model.List_Engineering_Services_Features_Obj = MasterManager.GetEngineeringServicesFeatures(null, EngSeId);
            Model.List_Engineering_Services_SubTopic_Obj = MasterManager.GetEngineeringServicesSubTopic(null, EngSeId);
            Model.List_Engineering_Services_Tabs_Obj = MasterManager.GetEngineeringServicesTabs(null, EngSeId);
            Model.List_EngSer_Gallery_Obj = MasterManager.GetEngSerGallery(null, EngSeId);
            return View(Model);
        }

        //public ActionResult EngineeringServiesDetails(string url, int? tabId)
        //{
        //    MasterModel Model = new MasterModel();
        //    IMasterManager MasterManager = new MasterManager();

        //    // ================= MAIN ENGINEERING SERVICE =================
        //    // Example: Power System Studies
        //    Model.Engineering_Services_Obj =MasterManager.GetEngineeringServices(0, url).FirstOrDefault();

        //    if (Model.Engineering_Services_Obj == null)return HttpNotFound();

        //    int EngSeId = Model.Engineering_Services_Obj.Engineering_Services_Id;

        //    // ================= SIDEBAR TABS (LEFT MENU) =================
        //    // Load all tabs related to this service
        //    Model.List_Engineering_Services_Tabs_Obj = MasterManager.GetEngineeringServicesTabs(null, EngSeId);

        //    // ================= SELECTED TAB (RIGHT CONTENT) =================
        //    // If user clicks a tab → tabId comes from URL
        //    // Else → load first tab by default
        //    Model.Engineering_Services_Tabs_Obj = tabId.HasValue ? Model.List_Engineering_Services_Tabs_Obj.FirstOrDefault(x => x.Engineering_Services_Tabs_Id == tabId): Model.List_Engineering_Services_Tabs_Obj.FirstOrDefault();

        //    // ================= APPLICATIONS =================
        //    Model.List_Engineering_Services_Applications_Obj = MasterManager.GetEngineeringServicesApplications(null, EngSeId);

        //    // ================= FEATURES =================
        //    Model.List_Engineering_Services_Features_Obj = MasterManager.GetEngineeringServicesFeatures(null, EngSeId);

        //    // ================= SUB TOPICS (OPTIONAL) =================
        //    Model.List_Engineering_Services_SubTopic_Obj = MasterManager.GetEngineeringServicesSubTopic(null, EngSeId);

        //    // ================= GALLERY =================
        //    Model.List_EngSer_Gallery_Obj = MasterManager.GetEngSerGallery(null, EngSeId);

        //    return View(Model);
        //}
        //public ActionResult EngineeringServiesDetails(string url)
        //{
        //    MasterModel Model = new MasterModel();
        //    IMasterManager MasterManager = new MasterManager();

        //    // ================= MAIN SERVICE =================
        //    Model.Engineering_Services_Obj =
        //        MasterManager.GetEngineeringServices(0, url).FirstOrDefault();

        //    if (Model.Engineering_Services_Obj == null)
        //        return HttpNotFound();

        //    int EngSeId = Model.Engineering_Services_Obj.Engineering_Services_Id;

        //    // ================= SUB TOPICS (LEFT SIDEBAR) =================
        //    Model.List_Engineering_Services_SubTopic_Obj =
        //        MasterManager.GetEngineeringServicesSubTopic(null, EngSeId);

        //    // ================= DEFAULT SELECTED SUBTOPIC =================
        //    // First subtopic will load on page load
        //    Model.Engineering_Services_SubTopic_Obj =
        //        Model.List_Engineering_Services_SubTopic_Obj.FirstOrDefault();

        //    // ================= OTHER SECTIONS =================
        //    Model.List_Engineering_Services_Applications_Obj =
        //        MasterManager.GetEngineeringServicesApplications(null, EngSeId);

        //    Model.List_Engineering_Services_Features_Obj =
        //        MasterManager.GetEngineeringServicesFeatures(null, EngSeId);

        //    Model.List_EngSer_Gallery_Obj =
        //        MasterManager.GetEngSerGallery(null, EngSeId);

        //    return View(Model);
        //}


        public ActionResult PowerSystemStudies()
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