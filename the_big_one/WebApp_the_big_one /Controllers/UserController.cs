using DomainApi;
using DomainApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userManager)
    {
        _userManager = userManager;
    }

    // POST: api/user
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        _userManager.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { user.UserID }, user);
    }
    
    // GET: api/user/{userId}
    [HttpGet("{userId}")]
    public IActionResult GetUser(int userId)
    {
        var user = _userManager.GetUser(userId);
        return Ok(user);
    }

    // PUT: api/user/{userId}
    [HttpPut("{userId}")]
    public IActionResult UpdateUser(int userId, [FromBody] User user)
    {
        var existingUser = _userManager.GetUser(userId);
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        _userManager.UpdateUser(userId, user.Username, user.Email, user.Password, user.FirstName, user.LastName);
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