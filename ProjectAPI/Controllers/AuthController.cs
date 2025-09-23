using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectAPI.ServiceInterfaces;
using ProjectAPI.ViewModel;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] VMAuth model)
        {
            if (model == null || string.IsNullOrEmpty(model.Username) || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest(new { Success = false, Message = "Invalid login request." });
            }

            var response = _authService.Login(model);  

            if (response.Success)
            {
                var token = response.Token;

                // Set token as HttpOnly Cookie
                Response.Cookies.Append("jwt", token, new CookieOptions
                {
                    HttpOnly = true,   // JS can't read it
                    Secure = true,     // only HTTPS
                    SameSite = SameSiteMode.Strict, // prevents CSRF
                    Expires = DateTime.UtcNow.AddHours(1) // match token expiry
                });
                return Ok(response);
            }
            else
            {
                return Unauthorized(new { Success = false, Message = response.Message });
            }
        }
    }
}
    