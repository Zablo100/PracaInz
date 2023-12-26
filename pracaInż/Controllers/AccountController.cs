using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pracaInż.Data;
using pracaInż.Models.ApiRequests;
using pracaInż.Models.ApiResponses;
using pracaInż.Models.DTO.Employees;
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
        private readonly AppDbcontext _context;

        public AccountController(UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,
            ITokenService tokenService,
            AppDbcontext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _context = context;
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

            var employee = await _context.Employees
                .FirstOrDefaultAsync(emp => emp.Username == request.Username);

            if(employee == null)
            {
                Error error = Error.Failure(description: "Konto nie zostało powiązane z pracownikiem");
                return BadRequest(error);
            }

            return new LoginResponse(new EmployeeDTO(employee), _tokenService.CreateToken(user));
        }

        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register(loginRequest request)
        {
            var user = new AppUser
            {
                UserName = request.Username
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded) return BadRequest();

            return new RegisterResponse(user.UserName, _tokenService.CreateToken(user));
        }
    }
}
