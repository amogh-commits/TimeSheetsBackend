using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets_App.Model;
using TimeSheets_App.Service;

namespace TimeSheets_App.Controllers
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
        [HttpPost("user")]
        public User AddUser([FromBody] User user)
        {
            return _authService.AddUser(user);
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequests loginRequests)
        {
            var token = _authService.Login(loginRequests);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(); 
            }

            return Ok(new { Token = token });
        }

    }
}
