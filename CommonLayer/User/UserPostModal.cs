using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.User
{
    public class UserPostModal
    {
        [RegularExpression(@"^[a-zA-Z]{3,}$",
        ErrorMessage = "Please enter valid first name")]
        public string fName { get; set; }
        [RegularExpression(@"^[a-zA-Z]{3,}$",
         ErrorMessage = "Please enter valid last name")] 
        public string lName { get; set; }
        [RegularExpression(@"^[6-9]{1}[0-9]{9}$",
      ErrorMessage = "Please enter correct phone number")]
        public string phoneNo { get; set; }
        [RegularExpression(@"^[a-zA-Z]{3,}$",
        ErrorMessage = "Please enter valid address")]
        public string address { get; set; }
        [RegularExpression(@"^[a-z0-9]+(.[a-z0-9]+)?@[a-z]+[.][a-z]{3}$",
        ErrorMessage = "Please enter correct Email address")]
        public string email { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9@!#$%^&*]{4,}$",
            ErrorMessage = "Please enter strong password")]
        public string password { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9@!#$%^&*]{4,}$",
           ErrorMessage = "Please enter strong password")]
        public string CPassword { get; set; }
       
    }
}