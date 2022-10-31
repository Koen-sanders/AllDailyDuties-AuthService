using AllDailyDuties_AuthService.Models.Users;
using AllDailyDuties_AuthService.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AllDailyDuties_AuthService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private IUserService _userService;
        private IMapper _mapper;
        public UserController(ILogger<UserController> logger, IUserService userService,
        IMapper mapper)
        {
            _logger = logger;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public IActionResult Create(CreateRequest model)
        {
            _userService.Create(model);
            return Ok(new { message = "User created" });
        }
    }
}