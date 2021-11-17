using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge_dtos;
using ShopBridge_services.Interfaces;
using System;
using System.Threading.Tasks;

namespace ShopBridge_api.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController : ControllerBase
    {
        public AuthenticationController(IAuthenticationServices auth)
        {
            _auth = auth;
        }
        public readonly IAuthenticationServices _auth;

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var getLogin = await _auth.Login(login);
                return Ok(getLogin);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }
    }
}
