using BusinessLayer.Interface;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Model;
using Common;
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveIndexSeo(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
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
                string FilePathForPhoto = "~/Upload/IndexSeo/ogimage/" + Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension;
                Model.Index_Seo_Obj.Index_Seo_Og_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveIndexSeo(Model.Index_Seo_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Seo Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Index Seo!";
            }
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
                string folderPath = Server.MapPath("~/Upload/Index/IndexSeoImage/");

                // ensure folder exists (THIS FIXES THE ERROR)
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Count existing images for same code
                string[] files = Directory.GetFiles(folderPath, Model.Index_Seo_Obj.Index_Seo_Code + "*");
                No = files.Length;

                string extension = Path.GetExtension(Model.Index_Seo_Og_Image.FileName);

                string fileName = Model.Index_Seo_Obj.Index_Seo_Code + "_" + No + extension;
                string fullSavePath = Path.Combine(folderPath, fileName);

                Model.Index_Seo_Og_Image.SaveAs(fullSavePath);

                Model.Index_Seo_Obj.Index_Seo_Og_Image = "~/Upload/Index/IndexSeoImage/" + fileName;
            }

            int Id = Manager.UpdateIndexSeo(Model.Index_Seo_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Seo Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Index Seo!";
            }
            return RedirectToAction("IndexSeo");
        }


        [HttpGet]
        public ActionResult DeleteIndexSeo(int Index_Seo_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexSeo(Index_Seo_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Seo Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Index Seo!";
            }
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

            // generate code
            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Index_Features_Obj.Index_Features_Code = "IFC-" + Code.ToString();

            // handle image upload
            if (Model.Index_Features_Image != null && Model.Index_Features_Image.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Upload/Index/IndexFeaturesImage/");

                // ensure directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // count existing files for this code
                string[] files = Directory.GetFiles(folderPath, Model.Index_Features_Obj.Index_Features_Code + "*");
                int No = files.Length; // start with existing count

                string extension = Path.GetExtension(Model.Index_Features_Image.FileName) ?? "";
                string fileName = $"{Model.Index_Features_Obj.Index_Features_Code}_{No}{extension}";
                string fullSavePath = Path.Combine(folderPath, fileName);

                // save file
                Model.Index_Features_Image.SaveAs(fullSavePath);

                // store virtual path in model
                Model.Index_Features_Obj.Index_Features_Image = "~/Upload/Index/IndexFeaturesImage/" + fileName;
            }

            int Id = Manager.SaveIndexFeatures(Model.Index_Features_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Features Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Index Features!";
            }
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

            // handle image upload (only if new file provided)
            if (Model.Index_Features_Image != null && Model.Index_Features_Image.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Upload/Index/IndexFeaturesImage/");

                // ensure directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // count existing files for this code
                string[] files = Directory.GetFiles(folderPath, Model.Index_Features_Obj.Index_Features_Code + "*");
                int No = files.Length;

                string extension = Path.GetExtension(Model.Index_Features_Image.FileName) ?? "";
                string fileName = $"{Model.Index_Features_Obj.Index_Features_Code}_{No}{extension}";
                string fullSavePath = Path.Combine(folderPath, fileName);

                // save file
                Model.Index_Features_Image.SaveAs(fullSavePath);

                // update virtual path in model
                Model.Index_Features_Obj.Index_Features_Image = "~/Upload/Index/IndexFeaturesImage/" + fileName;
            }

            int Id = Manager.UpdateIndexFeatures(Model.Index_Features_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Features Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Index Features!";
            }
            return RedirectToAction("IndexFeatures");
        }
        public ActionResult DeleteIndexFeatures(int Index_Features_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexFeatures(Index_Features_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Features Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Index Features!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Services Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Index Services!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Services Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Index Services!";
            }
            return RedirectToAction("IndexServices");
        }

        public ActionResult DeleteIndexServices(int Index_Services_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexServices(Index_Services_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Services Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Index Services!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Slider Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Index Slider!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Slider Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Index Slider!";
            }
            return RedirectToAction("IndexSlider");
        }

        public ActionResult DeleteIndexSlider(int Index_Slider_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexSlider(Index_Slider_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Slider Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Index Slider!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Team Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Index Team!";
            }
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
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Team Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Index Team!";
            }
            return RedirectToAction("IndexTeam");
        }

        public ActionResult DeleteIndexTeam(int Index_Team_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteIndexTeam(Index_Team_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Index Team Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Index Team !";
            }
            return RedirectToAction("IndexTeam");
        }

        #endregion

        #region Industries
        //[CookiesExpireFilter]
        public ActionResult Industries(int? Industries_Id)
        {
            AdminModel Model = new AdminModel();
            IAdminManager Manger = new AdminManager();
            Model.List_Industries_Obj = Manger.GetIndustries(0, null);

            if (Industries_Id.HasValue)
            {
                Model.Industries_Obj = Manger.GetIndustries(Industries_Id, null).FirstOrDefault();
            }

            return View(Model);
        }
        [HttpPost]
        //[CookiesExpireFilter]
        [ValidateInput(false)]
        public ActionResult SaveIndustries(AdminModel Model)
        {
            IAdminManager Manger = new AdminManager();
            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Industries_Obj.Industries_Code = "CL-" + Code.ToString();

            int No = 0;
            if (Model.Industries_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Industries/og_image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Industries_Obj.Industries_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }

                string extension = System.IO.Path.GetExtension(Model.Industries_Og_Image.FileName);
                Model.Industries_Og_Image.SaveAs(Server.MapPath("~/Upload/Industries/og_image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Industries/og_image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension;
                Model.Industries_Obj.Industries_Og_Image = FilePathForPhoto;
            }

            No = 0;
            if (Model.Industries_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Industries/image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Industries_Obj.Industries_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }

                string extension = System.IO.Path.GetExtension(Model.Industries_Image.FileName);
                Model.Industries_Image.SaveAs(Server.MapPath("~/Upload/Industries/image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Industries/image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension;
                Model.Industries_Obj.Industries_Image = FilePathForPhoto;
            }

            Model.Industries_Obj.Created_By = Convert.ToInt32(CookiesStateManager.Cookies_Logged_User_Id);
            Model.Industries_Obj.Created_IP = SystemIP();
            int Id = Manger.SaveIndustries(Model.Industries_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Industries Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Industries!";
            }
            return RedirectToAction("Industries");
        }
        [HttpPost]
        //[CookiesExpireFilter]
        [ValidateInput(false)]
        public ActionResult UpdateIndustries(AdminModel Model)
        {
            IAdminManager Manger = new AdminManager();
            int No = 0;
            if (Model.Industries_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Industries/og_image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Industries_Obj.Industries_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }

                string extension = System.IO.Path.GetExtension(Model.Industries_Og_Image.FileName);
                Model.Industries_Og_Image.SaveAs(Server.MapPath("~/Upload/Industries/og_image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Industries/og_image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension;
                Model.Industries_Obj.Industries_Og_Image = FilePathForPhoto;
            }

            No = 0;
            if (Model.Industries_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Industries/image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Industries_Obj.Industries_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }

                string extension = System.IO.Path.GetExtension(Model.Industries_Image.FileName);
                Model.Industries_Image.SaveAs(Server.MapPath("~/Upload/Industries/image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Industries/image/" + Model.Industries_Obj.Industries_Code + "_" + No + extension;
                Model.Industries_Obj.Industries_Image = FilePathForPhoto;
            }

            Model.Industries_Obj.Modified_On = DateTime.Now;
            Model.Industries_Obj.Modified_By = Convert.ToInt32(CookiesStateManager.Cookies_Logged_User_Id);
            Model.Industries_Obj.Modified_IP = SystemIP();

            int Id = Manger.UpdateIndustries(Model.Industries_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Industries Updated Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Industries!";
            }
            return RedirectToAction("Industries");
        }
        //[CookiesExpireFilter]
        public ActionResult DeleteIndustries(int Industries_Id)
        {
            IAdminManager Manger = new AdminManager();
            int Id = Manger.DeleteIndustries(Industries_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Industries Deleted Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Industries!";
            }
            return RedirectToAction("Industries");
        }
        #endregion

        #region Knowledge Base Category

        // [CookiesExpireFilter]
        public ActionResult KnowledgeBaseCategory(int? Knowledge_Base_Category_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manger = new MasterManager();

            Model.List_Knowledge_Base_Category_Obj = Manger.GetKnowledgeBaseCategory(0, null);

            if (Knowledge_Base_Category_Id.HasValue)
            {
                Model.Knowledge_Base_Category_Obj = Manger.GetKnowledgeBaseCategory(Knowledge_Base_Category_Id, null).FirstOrDefault();
            }

            return View(Model);
        }
        // [CookiesExpireFilter]
        public ActionResult SaveKnowledgeBaseCategory(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();

            Model.Knowledge_Base_Category_Obj.Created_By = Convert.ToInt32(CookiesStateManager.Cookies_Logged_User_Id);
            Model.Knowledge_Base_Category_Obj.Created_IP = SystemIP();
            int Id = Manger.SaveKnowledgeBaseCategory(Model.Knowledge_Base_Category_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Category Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Base Category!";
            }
            return RedirectToAction("KnowledgeBaseCategory");
        }
        // [CookiesExpireFilter]
        public ActionResult UpdateKnowledgeBaseCategory(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();

            Model.Knowledge_Base_Category_Obj.Modified_By = Convert.ToInt32(CookiesStateManager.Cookies_Logged_User_Id);
            Model.Knowledge_Base_Category_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_Base_Category_Obj.Modified_IP = SystemIP();
            int Id = Manger.UpdateKnowledgeBaseCategory(Model.Knowledge_Base_Category_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Category Updated Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Knowledge Base Category!";
            }
            return RedirectToAction("KnowledgeBaseCategory");
        }
        // [CookiesExpireFilter]
        public ActionResult DeleteKnowledgeBaseCategory(int Knowledge_Base_Category_Id)
        {
            IMasterManager Manger = new MasterManager();

            int Id = Manger.DeleteKnowledgeBaseCategory(Knowledge_Base_Category_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Category Deleted Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Base Category !";
            }
            return RedirectToAction("KnowledgeBaseCategory");
        }

        #endregion

        #region Knowledge Base
        public ActionResult KnowledgeBase(int? Knowledge_Base_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Knowledge_Base_Business_Obj = Manager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_Base_Category_Obj = Manager.GetKnowledgeBaseCategory(0, null);
            if (Knowledge_Base_Id.HasValue)
            {
                Model.Knowledge_Base_Obj = Manager.GetKnowledgeBase(Knowledge_Base_Id, 0, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveKnowledgeBase(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Knowledge_Base_Obj.Created_By = 1;
            Model.Knowledge_Base_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Knowledge_Base_Obj.Knowledge_Base_Code = "KBC-" + Code.ToString();
            int No = 0;
            if (Model.Knowledge_Base_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Knowledge/OGImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Base_Obj.Knowledge_Base_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Base_Og_Image.FileName);
                Model.Knowledge_Base_Og_Image.SaveAs(Server.MapPath("~/Upload/Knowledge/OGImage/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Knowledge/OGImage/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension;
                Model.Knowledge_Base_Obj.Knowledge_Base_Og_Image = FilePathForPhoto;
            }
            No = 0;
            if (Model.Knowledge_Base_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Knowledge/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Base_Obj.Knowledge_Base_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Base_Image.FileName);
                Model.Knowledge_Base_Image.SaveAs(Server.MapPath("~/Upload/Knowledge/Image/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Knowledge/Image/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension;
                Model.Knowledge_Base_Obj.Knowledge_Base_Image = FilePathForPhoto;
            }

            int Id = Manger.SaveKnowledgeBase(Model.Knowledge_Base_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Base!";
            }
            return RedirectToAction("KnowledgeBase");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateKnowledgeBase(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Knowledge_Base_Obj.Modified_By = 1;
            Model.Knowledge_Base_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_Base_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Knowledge_Base_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Knowledge/OGImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Base_Obj.Knowledge_Base_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Base_Og_Image.FileName);
                Model.Knowledge_Base_Og_Image.SaveAs(Server.MapPath("~/Upload/Knowledge/OGImage/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Knowledge/OGImage/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension;
                Model.Knowledge_Base_Obj.Knowledge_Base_Og_Image = FilePathForPhoto;
            }
            No = 0;
            if (Model.Knowledge_Base_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/Knowledge/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Base_Obj.Knowledge_Base_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Base_Image.FileName);
                Model.Knowledge_Base_Image.SaveAs(Server.MapPath("~/Upload/Knowledge/Image/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/Knowledge/Image/" + Model.Knowledge_Base_Obj.Knowledge_Base_Code + "_" + No + extension;
                Model.Knowledge_Base_Obj.Knowledge_Base_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateKnowledgeBase(Model.Knowledge_Base_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Knowledge Base!";
            }
            return RedirectToAction("KnowledgeBase");
        }
        public ActionResult DeleteKnowledgeBase(int Knowledge_Base_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteKnowledgeBase(Knowledge_Base_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Base Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Base!";
            }
            return RedirectToAction("KnowledgeBase");
        }
        #endregion

        #region Knowledge Card

        public ActionResult KnowledgeCard(int? Knowledge_Card_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            // Model.List_Knowledge_Base_Obj = Manager.GetKnowledgeBase(0, null);
            Model.List_Knowledge_Base_Business_Obj = Manager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_Card_Business_Obj = Manager.GetKnowledgeCard(0, 0);
            if (Knowledge_Card_Id.HasValue)
            {
                Model.Knowledge_Card_Obj = Manager.GetKnowledgeCard(Knowledge_Card_Id, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveKnowledgeCard(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Knowledge_Card_Obj.Created_By = 1;
            Model.Knowledge_Card_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Knowledge_Card_Obj.Knowledge_Card_Code = "KCC-" + Code.ToString();
            int No = 0;
            if (Model.Knowledge_Card_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeCard/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Card_Obj.Knowledge_Card_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Card_Image.FileName);
                Model.Knowledge_Card_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeCard/Image/" + Model.Knowledge_Card_Obj.Knowledge_Card_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeCard/Image/" + Model.Knowledge_Card_Obj.Knowledge_Card_Code + "_" + No + extension;
                Model.Knowledge_Card_Obj.Knowledge_Card_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveKnowledgeCard(Model.Knowledge_Card_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Card Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Card!";
            }
            return RedirectToAction("KnowledgeCard");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateKnowledgeCard(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Knowledge_Card_Obj.Modified_By = 1;
            Model.Knowledge_Card_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_Card_Obj.Modified_IP = SystemIP();

            int No = 0;
            if (Model.Knowledge_Card_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeCard/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_Card_Obj.Knowledge_Card_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_Card_Image.FileName);
                Model.Knowledge_Card_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeCard/Image/" + Model.Knowledge_Card_Obj.Knowledge_Card_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeCard/Image/" + Model.Knowledge_Card_Obj.Knowledge_Card_Code + "_" + No + extension;
                Model.Knowledge_Card_Obj.Knowledge_Card_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateKnowledgeCard(Model.Knowledge_Card_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Card Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Knowledge Card!";
            }
            return RedirectToAction("KnowledgeCard");
        }
        public ActionResult DeleteKnowledgeCard(int Knowledge_Card_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteKnowledgeCard(Knowledge_Card_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Card Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Card!";
            }
            return RedirectToAction("KnowledgeCard");
        }
        #endregion

        #region Knowledge FailureMode
        public ActionResult KnowledgeFailureMode(int? Knowledge_FailureMode_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            // Model.List_Knowledge_Base_Obj = Manager.GetKnowledgeBase(0, null);
            Model.List_Knowledge_Base_Business_Obj = Manager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_FailureMode_Business_Obj = Manager.GetKnowledgeFailureMode(0, 0);
            if (Knowledge_FailureMode_Id.HasValue)
            {
                Model.Knowledge_FailureMode_Obj = Manager.GetKnowledgeFailureMode(Knowledge_FailureMode_Id, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveKnowledgeFailureMode(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Knowledge_FailureMode_Obj.Created_By = 1;
            Model.Knowledge_FailureMode_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code = "KFMC-" + Code.ToString();
            int No = 0;
            if (Model.Knowledge_FailureMode_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeFailureMode/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_FailureMode_Image.FileName);
                Model.Knowledge_FailureMode_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeFailureMode/Image/" + Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeFailureMode/Image/" + Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "_" + No + extension;
                Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveKnowledgeFailureMode(Model.Knowledge_FailureMode_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Failure Mode Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Failure Mode!";
            }
            return RedirectToAction("KnowledgeFailureMode");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateKnowledgeFailureMode(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Knowledge_FailureMode_Obj.Modified_By = 1;
            Model.Knowledge_FailureMode_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_FailureMode_Obj.Modified_IP = SystemIP();

            int No = 0;

            if (Model.Knowledge_FailureMode_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeFailureMode/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_FailureMode_Image.FileName);
                Model.Knowledge_FailureMode_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeFailureMode/Image/" + Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeFailureMode/Image/" + Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Code + "_" + No + extension;
                Model.Knowledge_FailureMode_Obj.Knowledge_FailureMode_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateKnowledgeFailureMode(Model.Knowledge_FailureMode_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Failure Mode Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update KnowledgeFailureMode!";
            }
            return RedirectToAction("KnowledgeFailureMode");
        }
        public ActionResult DeleteKnowledgeFailureMode(int Knowledge_FailureMode_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteKnowledgeFailureMode(Knowledge_FailureMode_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Failure Mode Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Failure Mode!";
            }
            return RedirectToAction("KnowledgeFailureMode");
        }
        #endregion

        #region Knowledge RelatedSolution
        public ActionResult KnowledgeRelatedSolution(int? Knowledge_RelatedSolution_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            // Model.List_Knowledge_Base_Obj = Manager.GetKnowledgeBase(0, null);
            Model.List_Knowledge_Base_Business_Obj = Manager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_RelatedSolution_Business_Obj = Manager.GetKnowledgeRelatedSolution(0, 0);
            if (Knowledge_RelatedSolution_Id.HasValue)
            {
                Model.Knowledge_RelatedSolution_Obj = Manager.GetKnowledgeRelatedSolution(Knowledge_RelatedSolution_Id, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveKnowledgeRelatedSolution(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Knowledge_RelatedSolution_Obj.Created_By = 1;
            Model.Knowledge_RelatedSolution_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code = "KRSC-" + Code.ToString();
            int No = 0;
            if (Model.Knowledge_RelatedSolution_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeRelatedSolution/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_RelatedSolution_Image.FileName);
                Model.Knowledge_RelatedSolution_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeRelatedSolution/Image/" + Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeRelatedSolution/Image/" + Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "_" + No + extension;
                Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveKnowledgeRelatedSolution(Model.Knowledge_RelatedSolution_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Related Solution Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Related Solution!";
            }
            return RedirectToAction("KnowledgeRelatedSolution");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateKnowledgeRelatedSolution(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Knowledge_RelatedSolution_Obj.Modified_By = 1;
            Model.Knowledge_RelatedSolution_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_RelatedSolution_Obj.Modified_IP = SystemIP();

            int No = 0;

            if (Model.Knowledge_RelatedSolution_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeRelatedSolution/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_RelatedSolution_Image.FileName);
                Model.Knowledge_RelatedSolution_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeRelatedSolution/Image/" + Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeRelatedSolution/Image/" + Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Code + "_" + No + extension;
                Model.Knowledge_RelatedSolution_Obj.Knowledge_RelatedSolution_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateKnowledgeRelatedSolution(Model.Knowledge_RelatedSolution_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Related Solution Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Knowledge Related Solution!";
            }
            return RedirectToAction("KnowledgeRelatedSolution");
        }
        public ActionResult DeleteKnowledgeRelatedSolution(int Knowledge_RelatedSolution_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteKnowledgeRelatedSolution(Knowledge_RelatedSolution_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Related Solution Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Related olution!";
            }
            return RedirectToAction("KnowledgeRelatedSolution");
        }
        #endregion

        #region Knowledge WorkflowStep
        public ActionResult KnowledgeWorkflowStep(int? Knowledge_WorkflowStep_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            // Model.List_Knowledge_Base_Obj = Manager.GetKnowledgeBase(0, null);
            Model.List_Knowledge_Base_Business_Obj = Manager.GetKnowledgeBase(0, 0, null);
            Model.List_Knowledge_WorkflowStep_Business_Obj = Manager.GetKnowledgeWorkflowStep(0, 0);
            if (Knowledge_WorkflowStep_Id.HasValue)
            {
                Model.Knowledge_WorkflowStep_Obj = Manager.GetKnowledgeWorkflowStep(Knowledge_WorkflowStep_Id, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveKnowledgeWorkflowStep(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Knowledge_WorkflowStep_Obj.Created_By = 1;
            Model.Knowledge_WorkflowStep_Obj.Created_IP = SystemIP();

            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code = "KWFC-" + Code.ToString();
            int No = 0;
            if (Model.Knowledge_WorkflowStep_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeWorkflowStep/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_WorkflowStep_Image.FileName);
                Model.Knowledge_WorkflowStep_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeWorkflowStep/Image/" + Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeWorkflowStep/Image/" + Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "_" + No + extension;
                Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveKnowledgeWorkflowStep(Model.Knowledge_WorkflowStep_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Workflow Step Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Knowledge Workflow Step!";
            }
            return RedirectToAction("KnowledgeWorkflowStep");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateKnowledgeWorkflowStep(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Knowledge_WorkflowStep_Obj.Modified_By = 1;
            Model.Knowledge_WorkflowStep_Obj.Modified_On = DateTime.Now;
            Model.Knowledge_WorkflowStep_Obj.Modified_IP = SystemIP();

            int No = 0;

            if (Model.Knowledge_WorkflowStep_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/KnowledgeWorkflowStep/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Knowledge_WorkflowStep_Image.FileName);
                Model.Knowledge_WorkflowStep_Image.SaveAs(Server.MapPath("~/Upload/KnowledgeWorkflowStep/Image/" + Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/KnowledgeWorkflowStep/Image/" + Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Code + "_" + No + extension;
                Model.Knowledge_WorkflowStep_Obj.Knowledge_WorkflowStep_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateKnowledgeWorkflowStep(Model.Knowledge_WorkflowStep_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Work flow Step Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Knowledge Work flow Step!";
            }
            return RedirectToAction("KnowledgeWorkflowStep");
        }
        public ActionResult DeleteKnowledgeWorkflowStep(int Knowledge_WorkflowStep_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteKnowledgeWorkflowStep(Knowledge_WorkflowStep_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Knowledge Work flow Step Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Knowledge Work flow Step!";
            }
            return RedirectToAction("KnowledgeWorkflowStep");
        }
        #endregion

        #region Engineering Services
        public ActionResult EngineeringServices(int? Engineering_Services_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            if (Engineering_Services_Id.HasValue)
            {
                Model.Engineering_Services_Obj = Manager.GetEngineeringServices(Engineering_Services_Id, null).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServices(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_Obj.Created_By = 1;
            Model.Engineering_Services_Obj.Created_IP = SystemIP();
            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Engineering_Services_Obj.Engineering_Services_Code = "ESC-" + Code.ToString();
            int No = 0;
            if (Model.Engineering_Services_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/EngineeringServices/OGImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Engineering_Services_Obj.Engineering_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Og_Image.FileName);
                Model.Engineering_Services_Og_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension;
                Model.Engineering_Services_Obj.Engineering_Services_Og_Image = FilePathForPhoto;
            }
            No = 0;
            if (Model.Engineering_Services_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/EngineeringServices/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Engineering_Services_Obj.Engineering_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Image.FileName);
                Model.Engineering_Services_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServices/Image/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServices/Image/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension;
                Model.Engineering_Services_Obj.Engineering_Services_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveEngineeringServices(Model.Engineering_Services_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services!";
            }
            return RedirectToAction("EngineeringServices");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServices(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_Obj.Modified_By = 1;
            Model.Engineering_Services_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_Obj.Modified_IP = SystemIP();
            int No = 0;
            if (Model.Engineering_Services_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/EngineeringServices/OGImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Engineering_Services_Obj.Engineering_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Og_Image.FileName);
                Model.Engineering_Services_Og_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension;
                Model.Engineering_Services_Obj.Engineering_Services_Og_Image = FilePathForPhoto;
            }
            No = 0;
            if (Model.Engineering_Services_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/EngineeringServices/Image/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Engineering_Services_Obj.Engineering_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Image.FileName);
                Model.Engineering_Services_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServices/Image/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServices/Image/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension;
                Model.Engineering_Services_Obj.Engineering_Services_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateEngineeringServices(Model.Engineering_Services_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services!";
            }
            return RedirectToAction("EngineeringServices");
        }
        public ActionResult DeleteEngineeringServices(int Engineering_Services_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServices(Engineering_Services_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services!";
            }
            return RedirectToAction("EngineeringServices");
        }
        #endregion

        #region Engineering Services Features

        public ActionResult EngineeringServicesFeatures(int? Engineering_Services_Features_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            Model.List_Engineering_Services_Features_Obj = Manager.GetEngineeringServicesFeatures(0, 0);
            if (Engineering_Services_Features_Id.HasValue)
            {
                Model.Engineering_Services_Features_Obj = Manager.GetEngineeringServicesFeatures(Engineering_Services_Features_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServicesFeatures(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_Features_Obj.Created_By = 1;
            Model.Engineering_Services_Features_Obj.Created_IP = SystemIP();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            int Id = Manger.SaveEngineeringServicesFeatures(Model.Engineering_Services_Features_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Features Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services Features!";
            }
            return RedirectToAction("EngineeringServicesFeatures");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServicesFeatures(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_Features_Obj.Modified_By = 1;
            Model.Engineering_Services_Features_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_Features_Obj.Modified_IP = SystemIP();
            int Id = Manager.UpdateEngineeringServicesFeatures(Model.Engineering_Services_Features_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Features Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services Features!";
            }
            return RedirectToAction("EngineeringServicesFeatures");
        }
        public ActionResult DeleteEngineeringServicesFeatures(int Engineering_Services_Features_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServicesFeatures(Engineering_Services_Features_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Features Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services Features!";
            }
            return RedirectToAction("EngineeringServicesFeatures");
        }
        #endregion

        #region Engineering Services Applications

        public ActionResult EngineeringServicesApplications(int? Engineering_Services_Applications_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            Model.List_Engineering_Services_Applications_Obj = Manager.GetEngineeringServicesApplications(0, 0);
            if (Engineering_Services_Applications_Id.HasValue)
            {
                Model.Engineering_Services_Applications_Obj = Manager.GetEngineeringServicesApplications(Engineering_Services_Applications_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServicesApplications(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_Applications_Obj.Created_By = 1;
            Model.Engineering_Services_Applications_Obj.Created_IP = SystemIP();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            int Id = Manger.SaveEngineeringServicesApplications(Model.Engineering_Services_Applications_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Applications Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services Applications!";
            }
            return RedirectToAction("EngineeringServicesApplications");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServicesApplications(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_Applications_Obj.Modified_By = 1;
            Model.Engineering_Services_Applications_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_Applications_Obj.Modified_IP = SystemIP();
            int Id = Manager.UpdateEngineeringServicesApplications(Model.Engineering_Services_Applications_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Applications Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services Applications!";
            }
            return RedirectToAction("EngineeringServicesApplications");
        }
        public ActionResult DeleteEngineeringServicesApplications(int Engineering_Services_Applications_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServicesApplications(Engineering_Services_Applications_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Applications Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services Applications!";
            }
            return RedirectToAction("EngineeringServicesApplications");
        }
        #endregion

        #region Engineering Services Tabs

        public ActionResult EngineeringServicesTabs(int? Engineering_Services_Tabs_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            Model.List_Engineering_Services_Tabs_Obj = Manager.GetEngineeringServicesTabs(0, 0);
            if (Engineering_Services_Tabs_Id.HasValue)
            {
                Model.Engineering_Services_Tabs_Obj = Manager.GetEngineeringServicesTabs(Engineering_Services_Tabs_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServicesTabs(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_Tabs_Obj.Created_By = 1;
            Model.Engineering_Services_Tabs_Obj.Created_IP = SystemIP();
            int Id = Manger.SaveEngineeringServicesTabs(Model.Engineering_Services_Tabs_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Tabs Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services Tabs!";
            }
            return RedirectToAction("EngineeringServicesTabs");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServicesTabs(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_Tabs_Obj.Modified_By = 1;
            Model.Engineering_Services_Tabs_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_Tabs_Obj.Modified_IP = SystemIP();
            int Id = Manager.UpdateEngineeringServicesTabs(Model.Engineering_Services_Tabs_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Tabs Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services Tabs!";
            }
            return RedirectToAction("EngineeringServicesTabs");
        }
        public ActionResult DeleteEngineeringServicesTabs(int Engineering_Services_Tabs_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServicesTabs(Engineering_Services_Tabs_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Tabs Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services Tabs!";
            }
            return RedirectToAction("EngineeringServicesTabs");
        }
        #endregion

        #region Engineering Services SubTopic

        public ActionResult EngineeringServicesSubTopic(int? Engineering_Services_SubTopic_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            Model.List_Engineering_Services_SubTopic_Obj = Manager.GetEngineeringServicesSubTopic(0, 0);
            if (Engineering_Services_SubTopic_Id.HasValue)
            {
                Model.Engineering_Services_SubTopic_Obj = Manager.GetEngineeringServicesSubTopic(Engineering_Services_SubTopic_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServicesSubTopic(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_SubTopic_Obj.Created_By = 1;
            Model.Engineering_Services_SubTopic_Obj.Created_IP = SystemIP();
            ViewBag.IconList = IconCatalog.FeatureIcons;
            int Id = Manger.SaveEngineeringServicesSubTopic(Model.Engineering_Services_SubTopic_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services SubTopic Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services SubTopic!";
            }
            return RedirectToAction("EngineeringServicesSubTopic");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServicesSubTopic(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_SubTopic_Obj.Modified_By = 1;
            Model.Engineering_Services_SubTopic_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_SubTopic_Obj.Modified_IP = SystemIP();
            int Id = Manager.UpdateEngineeringServicesSubTopic(Model.Engineering_Services_SubTopic_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services SubTopic Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services SubTopic!";
            }
            return RedirectToAction("EngineeringServicesSubTopic");
        }
        public ActionResult DeleteEngineeringServicesSubTopic(int Engineering_Services_SubTopic_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServicesSubTopic(Engineering_Services_SubTopic_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services SubTopic Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services SubTopic!";
            }
            return RedirectToAction("EngineeringServicesSubTopic");
        }
        #endregion

        #region Engineering Services Gallery

        public ActionResult EngineeringServicesGallery(int? Engineering_Services_Gallery_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manager = new MasterManager();
            Model.List_Engineering_Services_Obj = Manager.GetEngineeringServices(0, null);
            Model.List_Engineering_Services_Gallery_Obj = Manager.GetEngineeringServicesGallery(0, 0);
            if (Engineering_Services_Gallery_Id.HasValue)
            {
                Model.Engineering_Services_Gallery_Obj = Manager.GetEngineeringServicesGallery(Engineering_Services_Gallery_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SaveEngineeringServicesGallery(MasterModel Model)
        {
            IMasterManager Manger = new MasterManager();
            Model.Engineering_Services_Gallery_Obj.Created_By = 1;
            Model.Engineering_Services_Gallery_Obj.Created_IP = SystemIP();
            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.Engineering_Services_Gallery_Obj.Engineering_Services_Gallery_Image_Code = "ESG-" + Code.ToString();
            int No = 0;
            if (Model.Engineering_Services_Gallery_Image != null)
            {
                string uploadPath = Request.MapPath("/Upload/EngineeringServicesGallery/Image/");
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string[] files = System.IO.Directory.GetFiles(uploadPath, (Model.Engineering_Services_Gallery_Obj.Engineering_Services_Gallery_Image_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Gallery_Image.FileName);
                Model.Engineering_Services_Gallery_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServicesGallery/Image/" + Model.Engineering_Services_Gallery_Obj.Engineering_Services_Gallery_Image_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServicesGallery/Image/" + Model.Engineering_Services_Gallery_Obj.Engineering_Services_Gallery_Image_Code + "_" + No + extension;
                Model.Engineering_Services_Gallery_Obj.Engineering_Services_Gallery_Image = FilePathForPhoto;
            }
            int Id = Manger.SaveEngineeringServicesGallery(Model.Engineering_Services_Gallery_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services Gallery!";
            }
            return RedirectToAction("EngineeringServicesGallery");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult UpdateEngineeringServicesGallery(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.Engineering_Services_Gallery_Obj.Modified_By = 1;
            Model.Engineering_Services_Gallery_Obj.Modified_On = DateTime.Now;
            Model.Engineering_Services_Gallery_Obj.Modified_IP = SystemIP();
            int No = 0;
            if (Model.Engineering_Services_Og_Image != null)
            {
                string fullPath = Request.MapPath("/Upload/EngineeringServices/OGImage/");
                string[] files = System.IO.Directory.GetFiles(fullPath, (Model.Engineering_Services_Obj.Engineering_Services_Code + "*"));
                foreach (string f in files)
                {
                    No += 1;
                }
                string extension = System.IO.Path.GetExtension(Model.Engineering_Services_Og_Image.FileName);
                Model.Engineering_Services_Og_Image.SaveAs(Server.MapPath("~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension));
                string FilePathForPhoto = "~/Upload/EngineeringServices/OGImage/" + Model.Engineering_Services_Obj.Engineering_Services_Code + "_" + No + extension;
                Model.Engineering_Services_Obj.Engineering_Services_Og_Image = FilePathForPhoto;
            }
            int Id = Manager.UpdateEngineeringServicesGallery(Model.Engineering_Services_Gallery_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services Gallery!";
            }
            return RedirectToAction("EngineeringServicesGallery");
        }
        public ActionResult DeleteEngineeringServicesGallery(int Engineering_Services_Gallery_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngineeringServicesGallery(Engineering_Services_Gallery_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services Gallery!";
            }
            return RedirectToAction("EngineeringServicesGallery");
        }
        #endregion

        #region EngSer Gallery
        public ActionResult EngSerGallery(int? EngSer_Gallery_Id)
        {
            MasterModel Model = new MasterModel();
            IMasterManager Manger = new MasterManager();
            Model.List_Engineering_Services_Obj = Manger.GetEngineeringServices(0, null);
            Model.List_EngSer_Gallery_Obj = Manger.GetEngSerGallery(0, 0);
            if (EngSer_Gallery_Id.HasValue)
            {
                Model.EngSer_Gallery_Obj = Manger.GetEngSerGallery(EngSer_Gallery_Id, 0).FirstOrDefault();
            }
            return View(Model);
        }
        public ActionResult SaveEngSerGallery(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.EngSer_Gallery_Obj.Created_By = 1;
            Model.EngSer_Gallery_Obj.Created_IP = SystemIP();

            // generate code
            Random rnd = new Random();
            int Code = rnd.Next(1000000, 9999999);
            Model.EngSer_Gallery_Obj.EngSer_Gallery_Code = "ESGC-" + Code.ToString();
            if (Model.EngSer_Gallery_Image_Url != null && Model.EngSer_Gallery_Image_Url.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Upload/EngSerGallery/ImageUrl/");

                // ensure directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // count existing files for this code
                string[] files = Directory.GetFiles(folderPath, Model.EngSer_Gallery_Obj.EngSer_Gallery_Code + "*");
                int No = files.Length; // start with existing count

                string extension = Path.GetExtension(Model.EngSer_Gallery_Image_Url.FileName) ?? "";
                string fileName = $"{Model.EngSer_Gallery_Obj.EngSer_Gallery_Code}_{No}{extension}";
                string fullSavePath = Path.Combine(folderPath, fileName);

                // save file
                Model.EngSer_Gallery_Image_Url.SaveAs(fullSavePath);

                // store virtual path in model
                Model.EngSer_Gallery_Obj.EngSer_Gallery_Image_Url = "~/Upload/EngSerGallery/ImageUrl/" + fileName;
            }
            int Id = Manager.SaveEngSerGallery(Model.EngSer_Gallery_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Added Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Add Engineering Services Gallery!";
            }
            return RedirectToAction("EngSerGallery");
        }

        public ActionResult UpdateEngSerGallery(MasterModel Model)
        {
            IMasterManager Manager = new MasterManager();
            Model.EngSer_Gallery_Obj.Modified_By = 1;
            Model.EngSer_Gallery_Obj.Modified_On = DateTime.Now;
            Model.EngSer_Gallery_Obj.Modified_IP = SystemIP();
            if (Model.EngSer_Gallery_Image_Url != null && Model.EngSer_Gallery_Image_Url.ContentLength > 0)
            {
                string folderPath = Server.MapPath("~/Upload/EngSerGallery/ImageUrl/");
                // ensure directory exists
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                // count existing files for this code
                string[] files = Directory.GetFiles(folderPath, Model.EngSer_Gallery_Obj.EngSer_Gallery_Code + "*");
                int No = files.Length; // start with existing count
                string extension = Path.GetExtension(Model.EngSer_Gallery_Image_Url.FileName) ?? "";
                string fileName = $"{Model.EngSer_Gallery_Obj.EngSer_Gallery_Code}_{No}{extension}";
                string fullSavePath = Path.Combine(folderPath, fileName);
                // save file
                Model.EngSer_Gallery_Image_Url.SaveAs(fullSavePath);
                // store virtual path in model
                Model.EngSer_Gallery_Obj.EngSer_Gallery_Image_Url = "~/Upload/EngSerGallery/ImageUrl/" + fileName;
            }
            int Id = Manager.UpdateEngSerGallery(Model.EngSer_Gallery_Obj);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Update Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Update Engineering Services Gallery!";
            }
            return RedirectToAction("EngSerGallery");
        }
        #endregion
        public ActionResult DeleteEngSerGallery(int EngSer_Gallery_Id)
        {
            IMasterManager Manager = new MasterManager();
            int Id = Manager.DeleteEngSerGallery(EngSer_Gallery_Id);
            if (Id != 0 && Id > 0)
            {
                TempData["AlertType"] = "success";
                TempData["AlertTitle"] = "SUCCESS";
                TempData["AlertMessage"] = "Engineering Services Gallery Delete Successfully !";
            }
            else
            {
                TempData["AlertType"] = "error";
                TempData["AlertTitle"] = "FAILED";
                TempData["AlertMessage"] = "Sorry, Failed to Delete Engineering Services Gallery!";
            }
            return RedirectToAction("EngSerGallery");
        }
    }
}