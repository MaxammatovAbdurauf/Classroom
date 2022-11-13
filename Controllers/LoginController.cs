using ClassRoomApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassRoomApi.Controllers;

[Route("[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly SignInManager<User> signInManager;
    private readonly RoleManager  <User> roleManager;
    private readonly UserManager  <User> userManager;

    public LoginController(SignInManager<User> _signInManager,
                             RoleManager<User> _roleManager,
                             UserManager<User> _userManager)
    {
        signInManager = _signInManager;
        roleManager   = _roleManager;
        userManager   = _userManager;
    }

    [HttpPost("Student")]
    public async Task<IActionResult> AddStudent(string name)
    {
        var user = new User
        {
            UserName = name,
        };
        
        await userManager.CreateAsync(user,"12345");
        await userManager.AddToRoleAsync(user, "Student");
        await signInManager.SignInAsync (user, isPersistent: true);
        return Ok();
    }

    [HttpPost("Teacher")]
    public async Task<IActionResult> AddTeacher(string name)
    {
        var user = new User
        {
            UserName = name,
        };
        var roles = new Roles();
        await userManager.CreateAsync(user, "12345");
        await userManager.AddToRoleAsync(user, "Teacher");
        await signInManager.SignInAsync(user, isPersistent: true);
        return Ok();
    }

    [HttpPost("Admin")]
    public async Task<IActionResult> AddAdmin(string name)
    {
        var user = new User
        {
            UserName = name,
        };
        var roles = new Roles();
        await userManager.CreateAsync(user, "12345");
        await userManager.AddToRoleAsync(user, "Admin");
        await signInManager.SignInAsync(user, isPersistent: true);
        return Ok();
    }
}