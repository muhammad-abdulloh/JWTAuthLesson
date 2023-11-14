using JWTAuthLesson.Models;
using JWTAuthLesson.Services.AuthServices;
using JWTAuthLesson.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;

        public AuthController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest loginRequest)
        {
            var user =   _userService.GetAllUsersAsync()
                .Result
                .FirstOrDefault(x => x.UserName == loginRequest.UserName && x.PasswordHash == loginRequest.Password);
            
            if (user == null)
            {
                return NotFound("Login yoki parol hato");
            }

            string token = await _authService.GenerateToken(loginRequest.UserName, user.Role);
            
            return Ok(token);
        }
    }
}
