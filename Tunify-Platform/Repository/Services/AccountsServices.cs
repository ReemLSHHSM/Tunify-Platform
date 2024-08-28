using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using Tunify_Platform.Models;
using Tunify_Platform.Models.DTOs;
using Tunify_Platform.Repository.Interfaces;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using static System.Net.Mime.MediaTypeNames;

namespace Tunify_Platform.Repository.Services
{
    public class AccountsServices : IAccounts
    {
        private UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private JwtTokenService _jwtTokenService;

        public AccountsServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, JwtTokenService jwtTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenService = jwtTokenService;
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
            var User = new IdentityUser()//its a model that holds needed attributes
            {
                UserName = registerDto.Name,
                Email = registerDto.Email,
            };
            //The UserManager class provides a centralized way to manage all user-related operations,
            //such as creating, updating, and deleting users.
            //This ensures that all user management logic is consistent and follows the same rules across the application.


            /*was var*/
            IdentityResult result = await _userManager.CreateAsync(User, registerDto.Password);


            //            The result variable is of type IdentityResult.This object indicates whether
            //            the operation to create the user was successful or not.
            //            IdentityResult has properties like Succeeded(a boolean indicating success)
            //            and Errors(a collection of error descriptions if the operation failed).

            if (result.Succeeded)
            {

                return new UserDto()
                {
                    Id = User.Id,
                    Username = registerDto.Name,
                };
            }
            foreach (var error in result.Errors)
            {
                //Depending on which keyword is found in the Code, it sets errorCode
                //    to the name of the registerDto parameter,
                //    which is the data transfer object used for user registration.

                var errorCode = error.Code.Contains("password") ? nameof(registerDto) :
                 error.Code.Contains("Email") ? nameof(registerDto) :
                 error.Code.Contains("Username") ? nameof(registerDto) : "";
                //nameof(registerDto) returns the name of the parameter as a string.
                //In this context, it's likely used to map the error to the correct model property.
                //If the error code does not contain any of these keywords, errorCode is set to an empty string "".
                modelState.AddModelError(errorCode, error.Description);
            }

            //The AddModelError method adds an error to the ModelState dictionary.
            //The first parameter, errorCode, specifies the key or field to which the error should be associated.
            //If it's empty (""), the error is added without associating it with a specific field.
            return null;
        }

        public async Task<UserDto> UserProfile(ClaimsPrincipal claimsPrincipal)
        {
            var user = await _userManager.GetUserAsync(claimsPrincipal);
            return new UserDto()
            {
                Id = user.Id,
                Username = user.UserName,
                Token = await _jwtTokenService.GenerateToken(user, System.TimeSpan.FromMinutes(3))

            };
        }
    }
}
//ModelState is a dictionary that stores the state of the model binding and validation in ASP.NET Core.
