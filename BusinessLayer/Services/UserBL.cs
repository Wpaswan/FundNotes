﻿using BusinessLayer.Interface;
using CommonLayer.User;
using RepositoryLayer.Entities;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Class
{


    public class UserBL : IUserBL
    {
        IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }
        public void RegisterUser(UserPostModal userPostModel)
        {
            try
            {
                userRL.RegistereUser(userPostModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string LogInUser(UserLogin userLogIn)
        {
            try
            {
                return userRL.LogInUser(userLogIn);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void ResetPassword(string email, string password, string cPassword)
        {
            try
            {
                userRL.ResetPassword(email, password, cPassword);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool ForgetPassword(string email)
        {
            try
            {
                return userRL.ForgetPassword(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                return userRL.GetAllUsers();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}

