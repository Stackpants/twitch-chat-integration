using Microsoft.AspNetCore.Mvc;


namespace Kestrel.TCI.Host.Web.Controllers;

public class ChatController : ControllerBase
{
    [HttpGet("connect/{string:channel}")]
    public IActionResult Connect(string channel)
    {
        return Ok("Hello");
    }
}
