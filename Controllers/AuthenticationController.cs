using Microsoft.AspNetCore.Mvc;

namespace WebAPI_Versioning.Controllers;

[Route("api/[controller]")]
[ApiController]
[ApiVersionNeutral]
public class AuthenticationController : ControllerBase
{
    [HttpGet("AuthenticateAsync")]
    public IActionResult AuthenticateAsync()
    {
        return Ok(new {message = "User authenticated", token = Guid.NewGuid()});
    }
}