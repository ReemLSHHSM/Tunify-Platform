using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Tunify_Platform.Models.DTOs;
using Tunify_Platform.Repository.Interfaces;

namespace Tunify_Platform.Repository.Services
{
    public class AccountsServices : IAccounts
    {
        private UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountsServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<UserDto> LogIn_User(string name, string password)
        {
            var user = await _userManager.FindByEmailAsync(name);

            bool password_validation = await _userManager.CheckPasswordAsync(user, password);

            if (password_validation == true)
            {
                return new UserDto()
                {
                    Id = user.Id,
                    Username = name,
                };

            }

            return null;
        }

        public async Task LogOut_User()
        {
            await _signInManager.SignOutAsync();
        }


        public async Task<UserDto> Register_User(RegisterDto registerDto, ModelStateDictionary modelState)
        {
            var User = new IdentityUser()
            {
                UserName = registerDto.Name,
                Email = registerDto.Email,
            };

          var result=await _userManager.CreateAsync(User,registerDto.Password);

            if (result.Succeeded) {

                return new UserDto()
                {
                    Id = User.Id,
                    Username = registerDto.Name,
                };

            }

            foreach (var error in result.Errors)
            {
                var errorCode = error.Code.Contains("password") ? nameof(registerDto) :
                                error.Code.Contains("Email") ? nameof(registerDto) :
                                error.Code.Contains("Username") ? nameof(registerDto) : "";
                modelState.AddModelError(errorCode, error.Description);
            }
            return null;
        }
    }
}
