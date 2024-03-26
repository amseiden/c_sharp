using Microsoft.AspNetCore.Mvc;
using DomainApi;
using DomainApi.Models;

namespace Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        // GET: api/user/{userId}
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userManager.GetUser(userId);
            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userManager.AddUser(user);
            return CreatedAtAction(nameof(GetUser), new { user.userId }, user);
        }

        // PUT: api/user/{userId}
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User user)
        {
            var existingUser = _userManager.GetUser(userId);
            existingUser.userName = user.userName;
            existingUser.email = user.email;
            existingUser.password = user.password;

            _userManager.UpdateUser(userId, user.userName, user.email, user.password);
            return NoContent(); 
        }

        // DELETE: api/user/{userId}
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            _userManager.GetUser(userId);

            _userManager.DeleteUser(userId);
            return NoContent(); 
        }
    }
}
