using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[controller]")]
public class InfoController : ControllerBase
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public InfoController(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet("client")]
    public IActionResult GetClientInfo()
    {
        var ipAddress = _httpContextAccessor.HttpContext.Connection.RemoteIpAddress?.ToString();
        var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"].ToString();

        return Ok(new { IpAddress = ipAddress, UserAgent = userAgent });
    }

    [HttpGet("server")]
    public IActionResult GetServerInfo()
    {
        var ipAddress = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.ToString();
        var os = Environment.OSVersion.ToString();

        var serverInfo = new {
            ServerIPAddress = ipAddress,
            OperatingSystem = os
        };
        
        return Ok(serverInfo);
    }
}