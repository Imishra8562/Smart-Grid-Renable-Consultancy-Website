
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interface
{
    public interface ISecurityManager
    {

        #region User
        int SaveUser(User Object);
        IList<User_Business> GetUser(int? User_Id, int? User_Role_Id, string Mobile_No, string Email_Id);
        int UpdateUser(User Object);
        int DeleteUser(int User_Id);
        #endregion
        #region UserRole

        int SaveUserRole(User_Role Object);
        IList<User_Role> GetUserRole(int? User_Role_Id);
        //int UpdateUserRole(User_Role Object);
        //int DeleteUserRole(int User_Role_Id);

        #endregion
        #region Login
        User_Business SignIn(string Email_Id, byte[] Password);

        #endregion
    }
}
