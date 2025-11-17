using BusinessLayer;
using BusinessLayer.Interface;
using Domain;
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

            // Always initialize the object to avoid null
            Model.Index_Seo_Obj = new Index_Seo();

            // List
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);

            // Edit mode
            if (Index_Seo_Id.HasValue)
            {
                Model.Index_Seo_Obj = Manager.GetIndexSeo(Index_Seo_Id, null).FirstOrDefault()?? new Index_Seo();
            }

            return View(Model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexSeo(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Seo_Obj.Created_By = 1;
            Model.Index_Seo_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Seo_Obj.Index_Seo_Code = "ISC-" + Code.ToString();
            int No = 0;
            if (Model.Index_Seo_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexSeoImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Seo_Obj.Index_Seo_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Seo_Og_Image.FileName);
                Model.Index_Seo_Og_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexSeoImage/" + Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexSeoImage/" + Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension;
                Model.Index_Seo_Obj.Index_Seo_Og_Image = FilePathForPhoto;
            }
            int Id = Manager.SaveIndexSeo(Model.Index_Seo_Obj);

            return RedirectToAction("IndexSeo");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateIndexSeo(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Seo_Obj.Modified_By = 1;
            Model.Index_Seo_Obj.Modified_On = DateTime.Now;
            Model.Index_Seo_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Index_Seo_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexSeoImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Seo_Obj.Index_Seo_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Seo_Og_Image.FileName);
                Model.Index_Seo_Og_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexSeoImage/" + Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexSeoImage/" + Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension;
                Model.Index_Seo_Obj.Index_Seo_Og_Image = FilePathForPhoto;
            }
            
            int Id = Manager.UpdateIndexSeo(Model.Index_Seo_Obj);

            return RedirectToAction("IndexSeo");
        }
        [HttpGet]
        public ActionResult DeleteIndexSeo(int Index_Seo_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexSeo(Index_Seo_Id);
           
            return RedirectToAction("IndexSeo");
        }
        #endregion

        #region Index Features
        public ActionResult IndexFeatures(int? Index_Features_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);
            Model.List_Index_Features_Business_Obj = Manager.GetIndexFeatures(0, 0);
            if (Index_Features_Id.HasValue)
            {
                Model.Index_Features_Obj = Manager.GetIndexFeatures(Index_Features_Id, 0).FirstOrDefault();
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexFeatures(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Features_Obj.Created_By = 1;
            Model.Index_Features_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Features_Obj.Index_Features_Code = "IFC-" + Code.ToString();
            int No = 0;
            if (Model.Index_Features_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexFeaturesImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Features_Obj.Index_Features_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Features_Image.FileName);
                Model.Index_Features_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexFeaturesImage/" + Model.Index_Features_Obj.Index_Features_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexFeaturesImage/" + Model.Index_Features_Obj.Index_Features_Code + "_" + No + extension;
                Model.Index_Features_Obj.Index_Features_Image = FilePathForPhoto;
            }
            int Id = Manager.SaveIndexFeatures(Model.Index_Features_Obj);

            return RedirectToAction("IndexFeatures");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateIndexFeatures(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Features_Obj.Modified_By = 1;
            Model.Index_Features_Obj.Modified_On = DateTime.Now;
            Model.Index_Features_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Index_Features_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexFeaturesImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Features_Obj.Index_Features_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Features_Image.FileName);
                Model.Index_Features_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexFeaturesImage/" + Model.Index_Features_Obj.Index_Features_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexFeaturesImage/" + Model.Index_Features_Obj.Index_Features_Code + "_" + No + extension;
                Model.Index_Features_Obj.Index_Features_Image = FilePathForPhoto;
            }

            int Id = Manager.UpdateIndexFeatures(Model.Index_Features_Obj);

            return RedirectToAction("IndexFeatures");
        }

        public ActionResult DeleteIndexFeatures(int Index_Features_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int id = Manager.DeleteIndexFeatures(Index_Features_Id);
            return RedirectToAction("IndexFeatures");
        }

        #endregion

        #region Index Services
        public ActionResult IndexServices(int? Index_Services_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);
            Model.List_Index_Services_Business_Obj = Manager.GetIndexServices(0, 0);
            if (Index_Services_Id.HasValue)
            {
                Model.Index_Services_Obj = Manager.GetIndexServices(Index_Services_Id, 0).FirstOrDefault();
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexServices(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Services_Obj.Created_By = 1;
            Model.Index_Services_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Services_Obj.Index_Services_Code = "ISIC-" + Code.ToString();
            int No = 0;
            if (Model.Index_Services_Icon != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexServicesIcon/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Services_Obj.Index_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Services_Icon.FileName);
                Model.Index_Services_Icon.SaveAs(Server.MapPath("~/Upload/Index/IndexServicesIcon/" + Model.Index_Services_Obj.Index_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexServicesIcon/" + Model.Index_Services_Obj.Index_Services_Code + "_" + No + extension;
                Model.Index_Services_Obj.Index_Services_Icon = FilePathForPhoto;
            }
            int Id = Manager.SaveIndexServices(Model.Index_Services_Obj);

            return RedirectToAction("IndexServices");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateIndexServices(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Services_Obj.Modified_By = 1;
            Model.Index_Services_Obj.Modified_On = DateTime.Now;
            Model.Index_Services_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Index_Services_Icon != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexServicesIcon/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Services_Obj.Index_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Services_Icon.FileName);
                Model.Index_Services_Icon.SaveAs(Server.MapPath("~/Upload/Index/IndexServicesIcon/" + Model.Index_Services_Obj.Index_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexServicesIcon/" + Model.Index_Services_Obj.Index_Services_Code + "_" + No + extension;
                Model.Index_Services_Obj.Index_Services_Icon = FilePathForPhoto;
            }

            int Id = Manager.UpdateIndexServices(Model.Index_Services_Obj);

            return RedirectToAction("IndexServices");
        }

        public ActionResult DeleteIndexServices(int Index_Services_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int id = Manager.DeleteIndexServices(Index_Services_Id);
            return RedirectToAction("IndexServices");
        }

        #endregion

        #region Index Slider
        public ActionResult IndexSlider(int? Index_Slider_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);
            Model.List_Index_Slider_Business_Obj = Manager.GetIndexSlider(0, 0);
            if (Index_Slider_Id.HasValue)
            {
                Model.Index_Slider_Obj = Manager.GetIndexSlider(Index_Slider_Id, 0).FirstOrDefault();
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexSlider(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Slider_Obj.Created_By = 1;
            Model.Index_Slider_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Slider_Obj.Index_Slider_Code = "ISIMC-" + Code.ToString();
            int No = 0;
            if (Model.Index_Slider_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexSliderImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Slider_Obj.Index_Slider_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Slider_Image.FileName);
                Model.Index_Slider_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexSliderImage/" + Model.Index_Slider_Obj.Index_Slider_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexSliderImage/" + Model.Index_Slider_Obj.Index_Slider_Code + "_" + No + extension;
                Model.Index_Slider_Obj.Index_Slider_Image = FilePathForPhoto;
            }
            int Id = Manager.SaveIndexSlider(Model.Index_Slider_Obj);

            return RedirectToAction("IndexSlider");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateIndexSlider(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Slider_Obj.Modified_By = 1;
            Model.Index_Slider_Obj.Modified_On = DateTime.Now;
            Model.Index_Slider_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Index_Slider_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexSliderImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Slider_Obj.Index_Slider_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Slider_Image.FileName);
                Model.Index_Slider_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexSliderImage/" + Model.Index_Slider_Obj.Index_Slider_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexSliderImage/" + Model.Index_Slider_Obj.Index_Slider_Code + "_" + No + extension;
                Model.Index_Slider_Obj.Index_Slider_Image = FilePathForPhoto;
            }

            int Id = Manager.UpdateIndexSlider(Model.Index_Slider_Obj);

            return RedirectToAction("IndexSlider");
        }

        public ActionResult DeleteIndexSlider(int Index_Slider_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int id = Manager.DeleteIndexSlider(Index_Slider_Id);
            return RedirectToAction("IndexSlider");
        }

        #endregion

        #region Index Team
        public ActionResult IndexTeam(int? Index_Team_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Index_Seo_Obj = Manager.GetIndexSeo(0, null);
            Model.List_Index_Team_Business_Obj = Manager.GetIndexTeam(0, 0);
            if (Index_Team_Id.HasValue)
            {
                Model.Index_Team_Obj = Manager.GetIndexTeam(Index_Team_Id, 0).FirstOrDefault();
            }

            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexTeam(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Team_Obj.Created_By = 1;
            Model.Index_Team_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Team_Obj.Index_Team_Member_Code = "ITMC-" + Code.ToString();
            int No = 0;
            if (Model.Index_Team_Member_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexTeamMemberImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Team_Obj.Index_Team_Member_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Team_Member_Image.FileName);
                Model.Index_Team_Member_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexTeamMemberImage/" + Model.Index_Team_Obj.Index_Team_Member_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexTeamMemberImage/" + Model.Index_Team_Obj.Index_Team_Member_Code + "_" + No + extension;
                Model.Index_Team_Obj.Index_Team_Member_Image = FilePathForPhoto;
            }
            int Id = Manager.SaveIndexTeam(Model.Index_Team_Obj);

            return RedirectToAction("IndexTeam");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateIndexTeam(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Index_Team_Obj.Modified_By = 1;
            Model.Index_Team_Obj.Modified_On = DateTime.Now;
            Model.Index_Team_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Index_Team_Member_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Index/IndexTeamMemberImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Index_Team_Obj.Index_Team_Member_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Index_Team_Member_Image.FileName);
                Model.Index_Team_Member_Image.SaveAs(Server.MapPath("~/Upload/Index/IndexTeamMemberImage/" + Model.Index_Team_Obj.Index_Team_Member_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Index/IndexTeamMemberImage/" + Model.Index_Team_Obj.Index_Team_Member_Code + "_" + No + extension;
                Model.Index_Team_Obj.Index_Team_Member_Image = FilePathForPhoto;
            }

            int Id = Manager.UpdateIndexTeam(Model.Index_Team_Obj);

            return RedirectToAction("IndexTeam");
        }

        public ActionResult DeleteIndexTeam(int Index_Team_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int id = Manager.DeleteIndexTeam(Index_Team_Id);
            return RedirectToAction("IndexTeam");
        }

        #endregion
    }
}
