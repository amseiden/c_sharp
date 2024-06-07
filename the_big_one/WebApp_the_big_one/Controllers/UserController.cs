// USER CONTROLLER

using DomainApi;
using DomainApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IUserManager userManager;
    public UserController(IUserManager userManager)
    {
        this.userManager = userManager;
    }

    // POST: api/user
    [HttpPost]
    public IActionResult CreateUser([FromBody] User user)
    {
        userManager.AddUser(user);
        return CreatedAtAction(nameof(GetUser), new { user.UserID }, user);
    }
    
    // GET: api/user/{userId}
    [HttpGet("{userId}")]
    public IActionResult GetUser(int userId)
    {
        var user = userManager.GetUser(userId);
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
        var existingUser = userManager.GetUser(userId);
        existingUser.Username = user.Username;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;

        userManager.UpdateUser(userId, user.Username, user.Email, user.Password, user.FirstName, user.LastName);
        return NoContent(); 
    }

    // DELETE: api/user/{userId}
    [HttpDelete("{userId}")]
    public IActionResult DeleteUser(int userId)
    {
        userManager.GetUser(userId);

        userManager.DeleteUser(userId);
        return NoContent(); 
    }
}