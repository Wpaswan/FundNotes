using BusinessLayer.Interface;
using CommonLayer.Address;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entities;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [ApiController]
    [Route("Address")]
    public class UserAddressController : ControllerBase
    {
        IAddressBL addressBL;
        FundooDBContext fundooDBContext;
        public UserAddressController(IAddressBL addressBL)
        {
            this.addressBL = addressBL;
        }
        [Authorize]
        [HttpPost(" AddUserAddress")]
        public IActionResult AddUserAddress(UserAddressPostModal userAddress)
        {
            try
            {

                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type == "userId").Value);


                 this.addressBL.AddUserAddress(userAddress, userid);
                
               
                    return this.Ok(new { success = true, Message = $"Address is created" });
               
               
               
                    return this.BadRequest(new { Success = false, message = "Address Type exists, it can't be added" });
                


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [Authorize]
        [HttpPut("updateUserAddress/{AddressId}")]
        public async Task<IActionResult> UpdateUserAddress(UserAddressPostModal userAddress, int AddressId)
        {
            try
            {
                var userId = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("userId", StringComparison.InvariantCultureIgnoreCase));
                int UserId = Int32.Parse(userId.Value);

                await this.addressBL.UpdateUserAddress(userAddress, UserId, AddressId);


                return this.Ok(new { success = true, Message = $"Address is updated successfull" });
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [Authorize]
        [HttpGet("GetAllAddress")]
        public async Task<ActionResult> GetAllAddress()
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);
                var addressList = new List<UserAddress>();
                addressList = await this.addressBL.GetAllAddress(userid);

                return this.Ok(new { Success = true, message = $"GetAll Address successfull ", data = addressList });

            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
