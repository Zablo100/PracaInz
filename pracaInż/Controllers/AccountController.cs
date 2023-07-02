using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using pracaInż.Models.ApiRequests;
using pracaInż.Models.ApiResponses;
using pracaInż.Models.Identity;
using pracaInż.Models.Services;
using System.Net;

namespace pracaInż.Controllers
{
    //Pa$$w0rd - hasło do testów
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> Login(loginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);

            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized();
            }

            return new LoginResponse(user.UserName, _tokenService.CreateToken(user));
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> Register(loginRequest request)
        {
            var user = new AppUser
            {
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) return BadRequest();

            return new LoginResponse(user.UserName, _tokenService.CreateToken(user));
        }
    }
}
