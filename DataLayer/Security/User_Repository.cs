using Domain;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace DataLayer
{
    public class User_Repository : BaseRepository<User>
    {
        public IList<User_Business> ListUser(int? User_Id, int? User_Role_Id, string Mobile_No, string Email_Id)
        {
            IList<User_Business> List_Obj = null;
            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_List_User");
                DataSet dataSet = new DataSet();

                var UserId = sqlCommand.CreateParameter();
                UserId.ParameterName = "User_Id";
                UserId.Value = User_Id;
                sqlCommand.Parameters.Add(UserId);

                var UserRoleId = sqlCommand.CreateParameter();
                UserRoleId.ParameterName = "User_Role_Id";
                UserRoleId.Value = User_Role_Id;
                sqlCommand.Parameters.Add(UserRoleId);

                var P3 = sqlCommand.CreateParameter();
                P3.ParameterName = "Mobile_No";
                P3.Value = Mobile_No;
                sqlCommand.Parameters.Add(P3);

                var P4 = sqlCommand.CreateParameter();
                P4.ParameterName = "Email_Id";
                P4.Value = Email_Id;
                sqlCommand.Parameters.Add(P4);

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<User_Business>(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return List_Obj;
        }

        public User_Business AuthenticateUser(string Email_Id, byte[] Password)
        {
            User_Business User_Business_Obj = new User_Business();
            IList<User_Business> List_Obj = null;

            try
            {
                DatabaseProviderFactory factory = new DatabaseProviderFactory();
                Database _db = factory.Create("DefConn");
                DbCommand sqlCommand = _db.GetStoredProcCommand("sp_Authenticate_User");
                DataSet dataSet = new DataSet();

                var p1 = sqlCommand.CreateParameter();
                p1.ParameterName = "Email_Id";
                p1.Value = Email_Id;
                sqlCommand.Parameters.Add(p1);

                var p2 = sqlCommand.CreateParameter();
                p2.ParameterName = "Password";
                p2.Value = Password;
                sqlCommand.Parameters.Add(p2);

                sqlCommand.CommandTimeout = 600;

                _db.LoadDataSet(sqlCommand, dataSet, TableName);

                DataSet ds = dataSet;
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                {
                    List_Obj = DataBaseUtil.DataTableToList<User_Business>(ds.Tables[0]);
                }
                User_Business_Obj = List_Obj.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return User_Business_Obj;
        }
    }
}
