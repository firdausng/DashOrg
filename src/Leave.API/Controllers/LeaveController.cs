using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leave.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class LeaveController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}
