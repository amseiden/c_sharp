using Common.Interfaces;
using DomainApi.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IUserManager _userManager;
        public UserController(IUserManager userManager)
        {
            this._userManager = userManager;
        }

        // POST: api/user
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            _userManager.AddUser(user);
            var userDto = new UserDto
            {
                UserID = user.UserID,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return Ok(userDto);
        }

        // GET: api/user/{userId}
        [HttpGet("{userId}")]
        public IActionResult GetUser(int userId)
        {
            var user = _userManager.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UserDto
            {
                UserID = user.UserID,
                Username = user.Username,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
            return Ok(userDto);
        }

        // PUT: api/user/{userId}
        [HttpPut("{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User user)
        {
            var existingUser = _userManager.GetUser(userId);
            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;

            _userManager.UpdateUser(userId, user.Username, user.Email, user.Password, user.FirstName, user.LastName);
            return NoContent();
        }

        // DELETE: api/user/{userId}
        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var user = _userManager.GetUser(userId);
            if (user == null)
            {
                return NotFound();
            }

            _userManager.DeleteUser(userId);
            return NoContent();
        }
    }
}