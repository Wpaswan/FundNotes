using CommonLayer.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IUserBL
    {
        void RegisterUser(UserPostModal userPostModel);
        string LogInUser(UserLogin userLogIn);
        void ResetPassword(string email, string password, string cPassword);
        bool ForgetPassword(string email);
        List<User> GetAllUsers();
    }
}
