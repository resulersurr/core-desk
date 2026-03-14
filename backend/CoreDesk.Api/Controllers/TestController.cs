using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDesk.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new
        {
            message = "CoreDesk API çalışıyor",
            time = DateTime.UtcNow
        });
    }

    [Authorize]
    [HttpGet("secure")]
    public IActionResult Secure()
    {
        return Ok(new
        {
            message = "Token geçerli, korumalı endpoint'e eriştin.",
            user = User.Identity?.Name
        });
    }
}