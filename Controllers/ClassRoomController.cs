using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ClassRoomApi.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ClassRoomApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ClassRoomController : ControllerBase
{
    [HttpGet]
    [Authorize (Roles ="Admin")]
    public IActionResult JoinToRoom (int roomId, string role)
    {
        return Ok("you joined to room");
    }

    [HttpPost]
    [Authorize(Roles ="Teacher")]

    public IActionResult CreateRoom (string roomname)
    {
        return Ok("you are ");
    }

    [HttpDelete]
    [Authorize (Roles = "Admin")]
    public IActionResult deleteRoom ()
    {
        return Ok();
    }
}