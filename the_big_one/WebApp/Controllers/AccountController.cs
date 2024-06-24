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

        public AccountController(IUserManager userManager, IPasswordHasher passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromForm] LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.VerifyCredentialsAsync(model.Username, model.Password);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(model);
            }
            
            //  set session / authentication cookie 

            return RedirectToAction("Index", "Home");
        }

        [HttpGet("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost("signup")]
        public IActionResult SignUp([FromForm] SignUpViewModel model)
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

            TempData["SuccessMessage"] = "User created successfully.";
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public IActionResult Logout()
        {
            // here I should clear session / authentication cookie 

            return RedirectToAction("Welcome", "Home");
        }
    }
}