using Microsoft.AspNetCore.Mvc;
using DomainApi;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager;
        private readonly IPasswordHasher _passwordHasher;

        public AccountController(IUserManager userManager, IPasswordHasher passwordHasher)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
        }
 
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.VerifyCredentialsAsync(model.Username, model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
    }
}