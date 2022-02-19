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
        [AllowAnonymous]
        [HttpPost("AddAddress")]
        public async Task<ActionResult> AddAddress(UserAddressPostModal userAddressPost)
        {
            try
            {

                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);

                await this.addressBL.AddAddress(userid, userAddressPost);

                return this.Ok(new { success = true, message = $"Address added successfully " });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpPut("UpdateAddress/{userId}")]
        public async Task<ActionResult> UpdateAddress(int userId, UserAddressPostModal userAddressPost)
        {
            try
            {

                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);

                await this.addressBL.UpdateAddress(userid, userAddressPost);

                return this.Ok(new { success = true, message = $"Address updated successfully of userId={userId}", data = userAddressPost });


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [Authorize]
        [HttpGet("GetAllAddress")]
        public async Task<IActionResult> GetAllAddress()
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);
                var addressList = new List<UserAddress>();
                addressList = await this.addressBL.GetAllAddress(userid);

                return this.Ok(new { Success = true, message = $"GetAll note successfull ", data = addressList });

            }
            catch (Exception)
            {

                throw;
            }
        }
        [Authorize]
        [HttpDelete("DeleteAddress/{userId}")]
        public async Task<ActionResult> DeleteAddress(int userId)
        {
            try
            {
                int userid = Convert.ToInt32(User.Claims.FirstOrDefault(x => x.Type=="userId").Value);
                await this.addressBL.DeleteAddress(userid);
                return this.Ok(new { success = true, message = $"Address deleted of userId={userId}" });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




    }
}
