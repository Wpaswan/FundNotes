using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.Address
{
    public class UserAddressPostModal
    {
       
        [Required]
       
        public string Address { get; set; }
        [Required]
       
        public string City { get; set; }
        
        public string State { get; set; }
       
    }
}
