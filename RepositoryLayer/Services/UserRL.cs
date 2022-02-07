using CommonLayer.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Class
{
   
    public class UserRL :IUserRL
    {
        FundooDBContext dbContext;
        private readonly IConfiguration configuration;
        public UserRL(FundooDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void RegistereUser(UserPostModal userPostModel)
        {
            try
            {
                User user = new User();
                user.userId = new User().userId;
                user.fName = userPostModel.fName;
                user.lName = userPostModel.lName;
                user.phoneNo = userPostModel.phoneNo;
                user.address = userPostModel.address;
                user.email = userPostModel.email;
                user.password =  StringCipher.Encrypt(userPostModel.password);
                user.CPassword = userPostModel.CPassword;
                user.registeredDate = DateTime.Now;
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
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
                User user = new User();
                var result = dbContext.Users.Where(x => x.email == userLogIn.email && x.password == userLogIn.password).FirstOrDefault();
                if (result != null)
                    return GenerateJWTToken(userLogIn.email, user.userId);
                else
                    return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        private  string GenerateJWTToken(string email, int userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("email", email),
                    new Claim("userId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        public void ForgetPassword(string email)
        {
            try
            {
                User user = new User();
                var result = dbContext.Users.Where(x => x.email == email).FirstOrDefault();
                //if (result != null)
                //{
                //    //var token = GenerateJWTToken(email);
                //    return true;
                //}
                //else
                //    return false;
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
                User user = new User();
                var result = dbContext.Users.FirstOrDefault(x => x.email == email);
                if (result != null)
                {
                    result.password = password;
                    result.CPassword = cPassword;
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

       
    }
}
