using JWTAuthLesson.Entities;
using JWTAuthLesson.Services.UserServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthLesson.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public readonly ILogger<UsersController> Logger;

        public UsersController(IUserService userService, ILogger<UsersController> logger)
        {
            _userService = userService;
            Logger = logger;
        }

        // role based authenfication
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async ValueTask<IActionResult> Get()
        {
            try
            {
                IEnumerable<User> users = await _userService.GetAllUsersAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message);
                return BadRequest("Users not found or Some exception");
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetAdmin()
        {
            return Ok("Bu admin roli");
        }

        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult GetManager()
        {
            return Ok("Bu Manager roli");
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        public IActionResult GetTeacher()
        {
            return Ok("Bu Teacher roli");
        }

        [Authorize(Roles = "Teacher,Admin,Student,Dekan")]
        [HttpGet]
        public IActionResult Olorilar()
        {
            return Ok("Bu Teacher,Admin,Student,Dekan shular uchun mahsus roli");
        }
    }
}
