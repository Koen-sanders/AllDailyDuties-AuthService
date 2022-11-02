
using AllDailyDuties_AuthService.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AllDailyDuties_AuthService.Models.Users;

namespace AllDailyDuties_AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        private IMapper _mapper;
        private IOptions<ISettings> _settings;
        public LoginController(ILogger<UserController> logger, IUserService userService,
        IMapper mapper, IOptions<ISettings> settings)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
            _settings = settings;
        }
        [HttpPost]
        public IActionResult Login(AuthRequest model)
        {
            var loginResult = _userService.Authenticate(model);
            return Ok(loginResult);

        }
    }
}
