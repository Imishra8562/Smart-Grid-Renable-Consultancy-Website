using BusinessLayer.Interface;
using DataLayer;
using Domain;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLayer
{
    public class SecurityManager : ISecurityManager

    {
        #region User
        public int SaveUser(User User_Object)
        {
            int Id = 0;
            try
            {
                User_Repository db = new User_Repository();
                Id = db.Add(User_Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<User_Business> GetUser(int? User_Id, int? User_Role_Id, string Mobile_No, string Email_Id)
        {
            IList<User_Business> ListObj = new List<User_Business>();
            try
            {
                User_Repository db = new User_Repository();
                ListObj = db.ListUser(User_Id, User_Role_Id, Mobile_No, Email_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }
        public int UpdateUser(User User_Object)
        {
            int Id = 0;
            try
            {
                User_Repository db = new User_Repository();
                Id = db.Update(User_Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public int DeleteUser(int User_Id)
        {
            int Id = 0;
            try
            {
                User_Repository db = new User_Repository();
                Id = db.Delete(User_Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }

        #endregion

        #region UserRole

        public int SaveUserRole(User_Role User_Role_Object)
        {
            int Id = 0;
            try
            {
                User_Role_Repository db = new User_Role_Repository();
                Id = db.Add(User_Role_Object);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Id;
        }
        public IList<User_Role> GetUserRole(int? User_Role_Id)
        {
            IList<User_Role> ListObj = new List<User_Role>();
            try
            {
                User_Role_Repository db = new User_Role_Repository();
                DataSet ds = db.List(User_Role_Id);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    ListObj = DataBaseUtil.DataTableToList<User_Role>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ListObj;
        }

        #endregion

        #region Login

        public User_Business SignIn(string Email_Id, byte[] Password)
        {
            User_Business User_Business_Obj = null;
            try
            {
                User_Repository db = new User_Repository();
                User_Business_Obj = db.AuthenticateUser(Email_Id, Password);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return User_Business_Obj;
        }

        #endregion
    }
}
