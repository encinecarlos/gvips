using Gvips.API.Services;
using Gvips.API.ViewModels;
using Gvips.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gvips.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _login;

        public LoginController(LoginService login)
        {
            _login = login;
        }

        [HttpPost("authorize")]
        public ActionResult<UserViewModel> Login(LoginViewModel user) => _login.login(user);
    }
}