using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using ShopBridge_dtos;
using ShopBridge_model;
using ShopBridge_services.Interfaces;
using System.Threading.Tasks;

namespace ShopBridge_services.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        public AuthenticationServices(UserManager<AppUsers> userManager)
        {
            _userManager = userManager;
        }
        private readonly UserManager<AppUsers> _userManager; 

        public async Task<Response<string>> Login(LoginDto login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                return Response<string>.Success("Login Successful", user.Id, StatusCodes.Status200OK);
            }
            return Response<string>.Fail("Invalid Credentials", StatusCodes.Status404NotFound);
        }
    }
}
