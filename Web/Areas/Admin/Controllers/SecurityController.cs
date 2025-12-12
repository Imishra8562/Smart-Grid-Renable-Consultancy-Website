using BusinessLayer;
using BusinessLayer.Interface;
using Common;
using Domain;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Web.Controllers;
using Web.Models;

namespace Web.Areas.Admin.Controllers
{
    public class SecurityController : Controller
    {
        // GET: Admin/Security
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Forgetpassword()
        {
            return View();
        }


        public ActionResult AdminUser()
        {
            SecurityModel Model = new SecurityModel();
            ISecurityManager Manger = new SecurityManager();
            Model.List_User_Role_Obj = Manger.GetUserRole(0);
            Model.List_User_Obj = Manger.GetUser(0, 0, null, null);
            return View(Model);
        }
        public ActionResult SaveUser(SecurityModel Model)
        {
            ISecurityManager Manger = new SecurityManager();
            Model.User_Obj.Password = Encoding.ASCII.GetBytes(Model.Password);

            Model.User_Obj.Created_By = 1;

            int i = Manger.SaveUser(Model.User_Obj);

            return RedirectToAction("AdminUser");
        }
        public ActionResult EditUser(int User_Id)
        {
            SecurityModel Model = new SecurityModel();
            ISecurityManager Manger = new SecurityManager();
            Model.List_User_Role_Obj = Manger.GetUserRole(0);
            Model.User_Obj = Manger.GetUser(User_Id, 0, null, null).FirstOrDefault();
            return View(Model);
        }
        public ActionResult UpdateUser(SecurityModel Model)
        {
            ISecurityManager Manger = new SecurityManager();


            Model.User_Obj.Created_By = 1;

            int i = Manger.UpdateUser(Model.User_Obj);

            return RedirectToAction("AdminUser");
        }
        public ActionResult DeleteUser(int User_Id)
        {
            ISecurityManager Manger = new SecurityManager();

            int i = Manger.DeleteUser(User_Id);

            return RedirectToAction("AdminUser");
        }

        public ActionResult AuthenticateUser(string Email_Id, string Password)
        {
            ISecurityManager SecurityManager_Obj = new SecurityManager();
            User_Business User_Business_Obj = new User_Business();

            byte[] Secured_Password = Encoding.ASCII.GetBytes(Password);

            User_Business_Obj = SecurityManager_Obj.SignIn(Email_Id, Secured_Password);
            if (User_Business_Obj != null)
            {
                if (User_Business_Obj.FK_User_Role_Id == 0)
                {
                    Common.AuthenticationManager.SignOutCurrentUser();
                    CookiesStateManager.Cookies_Logged_User_Id = null;
                    CookiesStateManager.Cookies_Logged_User_Name = null;
                    CookiesStateManager.Cookies_Logged_Email_Id = null;
                    CookiesStateManager.Cookies_Logged_User_Role_Id = null;
                    CookiesStateManager.Cookies_Logged_User_Role_Name = null;
                    CookiesStateManager.Cookies_Logged_Profile_Id = null;
                    TempData["DisplayMessage"] = "Incorrect";
                    return RedirectToAction("Login", "Home");
                }
                else
                {
                    if (User_Business_Obj.FK_User_Role_Id == 2)
                    {
                        if (User_Business_Obj.Is_Locked == false)
                        {
                            ISecurityManager ISecurityManager_Obj = new SecurityManager();
                            User_Business User_Profile_Business_Obj = ISecurityManager_Obj.GetUser(0, 0, null, null).FirstOrDefault();

                            User_Business_Obj.Last_Login = DateTime.Now;
                            SecurityManager_Obj.UpdateUser(User_Business_Obj);

                            CookiesStateManager.Cookies_Logged_User_Id = User_Business_Obj.User_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Name = User_Business_Obj.User_Name;
                            CookiesStateManager.Cookies_Logged_Email_Id = User_Business_Obj.Email_Id;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = User_Business_Obj.FK_User_Role_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Role_Name = User_Business_Obj.User_Role_Name;
                            TempData["DisplayMessage"] = "Logged";

                            return RedirectToAction("AdminDashboard", "Admin");

                        }

                        else
                        {
                            Common.AuthenticationManager.SignOutCurrentUser();
                            CookiesStateManager.Cookies_Logged_User_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Name = null;
                            CookiesStateManager.Cookies_Logged_Email_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Name = null;
                            CookiesStateManager.Cookies_Logged_Profile_Id = null;
                            //CookiesStateManager.Cookies_Logged_Display_Name = null;

                            TempData["DisplayMessage"] = "Locked";
                            return RedirectToAction("Login", "Secutity");
                        }
                    }
                    else if (User_Business_Obj.FK_User_Role_Id == 3)
                    {
                        if (User_Business_Obj.Is_Locked == false)
                        {
                            ISecurityManager ISecurityManager_Obj = new SecurityManager();
                            User_Business User_Profile_Business_Obj = ISecurityManager_Obj.GetUser(0, 0, null, null).FirstOrDefault();

                            User_Business_Obj.Last_Login = DateTime.Now;
                            SecurityManager_Obj.UpdateUser(User_Business_Obj);

                            CookiesStateManager.Cookies_Logged_User_Id = User_Business_Obj.User_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Name = User_Business_Obj.User_Name;
                            CookiesStateManager.Cookies_Logged_Email_Id = User_Business_Obj.Email_Id;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = User_Business_Obj.FK_User_Role_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Role_Name = User_Business_Obj.User_Role_Name;

                            TempData["DisplayMessage"] = "Logged";

                            return RedirectToAction("EmployeeDashboard", "Admin");

                        }

                        else
                        {
                            Common.AuthenticationManager.SignOutCurrentUser();
                            CookiesStateManager.Cookies_Logged_User_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Name = null;
                            CookiesStateManager.Cookies_Logged_Email_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Name = null;
                            CookiesStateManager.Cookies_Logged_Profile_Id = null;
                            //CookiesStateManager.Cookies_Logged_Display_Name = null;

                            TempData["DisplayMessage"] = "Locked";
                            return RedirectToAction("Login", "Secutity");
                        }
                    }
                    else if (User_Business_Obj.FK_User_Role_Id == 4)
                    {
                        if (User_Business_Obj.Is_Locked == false)
                        {
                            ISecurityManager ISecurityManager_Obj = new SecurityManager();
                            User_Business User_Profile_Business_Obj = ISecurityManager_Obj.GetUser(0, 0, null, null).FirstOrDefault();

                            User_Business_Obj.Last_Login = DateTime.Now;
                            SecurityManager_Obj.UpdateUser(User_Business_Obj);

                            CookiesStateManager.Cookies_Logged_User_Id = User_Business_Obj.User_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Name = User_Business_Obj.User_Name;
                            CookiesStateManager.Cookies_Logged_Email_Id = User_Business_Obj.Email_Id;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = User_Business_Obj.FK_User_Role_Id.ToString();
                            CookiesStateManager.Cookies_Logged_User_Role_Name = User_Business_Obj.User_Role_Name;

                            TempData["DisplayMessage"] = "Logged";

                            return RedirectToAction("EmployeeDashboard", "Admin");

                        }

                        else
                        {
                            Common.AuthenticationManager.SignOutCurrentUser();
                            CookiesStateManager.Cookies_Logged_User_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Name = null;
                            CookiesStateManager.Cookies_Logged_Email_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Id = null;
                            CookiesStateManager.Cookies_Logged_User_Role_Name = null;
                            CookiesStateManager.Cookies_Logged_Profile_Id = null;
                            //CookiesStateManager.Cookies_Logged_Display_Name = null;

                            TempData["DisplayMessage"] = "Locked";
                            return RedirectToAction("Login", "Secutity");
                        }
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
            }
            else
            {
                Common.AuthenticationManager.SignOutCurrentUser();
                CookiesStateManager.Cookies_Logged_User_Id = null;
                CookiesStateManager.Cookies_Logged_User_Name = null;
                CookiesStateManager.Cookies_Logged_Email_Id = null;
                CookiesStateManager.Cookies_Logged_User_Role_Id = null;
                CookiesStateManager.Cookies_Logged_User_Role_Name = null;
                CookiesStateManager.Cookies_Logged_Profile_Id = null;
                //CookiesStateManager.Cookies_Logged_Display_Name = null;


                TempData["AlertType"] = "Error";
                TempData["AlertMessage"] = "Sorry, login credential does not match !";

                return RedirectToAction("Login");
            }
        }


        #region Logout

        public ActionResult Logout()
        {
            Common.AuthenticationManager.SignOutCurrentUser();
            CookiesStateManager.Cookies_Logged_User_Id = null;
            CookiesStateManager.Cookies_Logged_User_Name = null;
            CookiesStateManager.Cookies_Logged_Email_Id = null;
            CookiesStateManager.Cookies_Logged_User_Role_Id = null;
            CookiesStateManager.Cookies_Logged_User_Role_Name = null;
            return RedirectToAction("Login");
        }
        #endregion

    }
}