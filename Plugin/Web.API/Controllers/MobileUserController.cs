using CloudVOffice.Core.Domain.Common;
using CloudVOffice.Data.DTO.CyclePredictor;
using CloudVOffice.Services.CyclePredictor;
using LinqToDB.Tools;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MobileUserController : Controller
    {
        private readonly IMobileUserService _mobileUserService;
        public MobileUserController(IMobileUserService mobileUserService)
        {
            _mobileUserService = mobileUserService;
        }
        [HttpPost]
        public IActionResult MobileUserCreate(MobileUserDTO mobileUserDTO)
        {
            try
            {
                var result = _mobileUserService.MobileUserCreate(mobileUserDTO);

                switch (result)
                {
                    case MessageEnum.Success:
                        return Ok("User created successfully.");
                    case MessageEnum.AlreadyCreate:
                        return Conflict("User already exists.");
                    case MessageEnum.UnExpectedError:
                        return StatusCode(500, "Unexpected error occurred.");
                    default:
                        return BadRequest("Invalid request.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            try
            {
                var user = _mobileUserService.Login(email, password);
                if (user != null)
                {
                    return Ok("Login Successful");
                }
                else
                {
                    //Login fail
                    return Unauthorized("Invalid credentials");
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}