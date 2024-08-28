using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;
using Tunify_Platform.Models.DTOs;

namespace Tunify_Platform.Repository.Interfaces
{
    public interface IAccounts
    {

        public Task<UserDto> Register_User(RegisterDto registerDto, ModelStateDictionary modelState);

        public Task<UserDto> LogIn_User(string name, string password);

        public Task LogOut_User();

        public Task<UserDto> UserProfile(ClaimsPrincipal claimsPrincipal);

    }
}
