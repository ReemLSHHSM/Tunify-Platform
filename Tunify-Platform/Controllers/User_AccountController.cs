using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models.DTOs;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class User_AccountController : Controller
    {

        private readonly IAccounts _accounts;

        public User_AccountController(IAccounts accounts)
        {
            _accounts = accounts;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {

            var user = await _accounts.Register_User(registerDto, this.ModelState);

            if (ModelState.IsValid) {

                return user;
            }
            if (user == null)
            {
                return Unauthorized();
            }
            return BadRequest();
        }

        [HttpPost("logIn")]
        public async Task<ActionResult<UserDto>> LogIn(string name, string password)
        {
            var user=_accounts.LogIn_User(name, password);
            if (user == null)
            {
                return Unauthorized();
            }
            return await user;
        }

        [HttpPost("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await _accounts.LogOut_User();
            return Ok();
        }


        [Authorize(Roles = "User, Admin")]
        [HttpGet("profile")]
        public async Task<ActionResult<UserDto>> UserProfile()
        {
            return await _accounts.UserProfile(User);

        }

    }





    }

