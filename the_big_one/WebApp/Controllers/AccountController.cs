using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    [ApiController]
    [Route("account")]
    [Produces("application/json")]
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IUserManager userManager, IPasswordHasher passwordHasher, ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            _logger.LogInformation("Login attempt for user: {Username}", model.Username);
            
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Model state is invalid for user: {Username}", model.Username);
                return BadRequest(ModelState);
            }

            var user = await _userManager.VerifyCredentialsAsync(model.Username, model.Password);
            if (user == null)
            {
                _logger.LogWarning("Invalid login attempt for user: {Username}", model.Username);
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }

            _logger.LogInformation("Login successful for user: {Username}", model.Username);
            return Ok(new { Message = "Login successful" });
        }

        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        [ValidateAntiForgeryToken]
        public IActionResult SignUp([FromBody] SignUpViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.Password != model.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match.");
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Username = model.Username,
                Email = model.Email,
                Password = _passwordHasher.Hash(model.Password),
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _userManager.AddUser(user);

            return Ok(new { Message = "User created successfully" });
        }
    }
}
