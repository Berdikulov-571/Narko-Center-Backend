using Autorization.Interfaces;
using Autorization.Models;
using Microsoft.AspNetCore.Mvc;

namespace NarkoCenter.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> LoginAsync(Login login)
        {
            string token = await _authService.GenerateToken(login);

            return Ok(token);
        }
    }
}