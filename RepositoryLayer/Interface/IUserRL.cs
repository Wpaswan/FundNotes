﻿using CommonLayer.User;
using RepositoryLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {
        void RegistereUser(UserPostModal userPostModel);
        string LogInUser(UserLogin userLogIn);
        bool ForgetPassword(string email);
        void ResetPassword(string email, string password, string cPassword);
        
        List<User> GetAllUsers();
    }
}
