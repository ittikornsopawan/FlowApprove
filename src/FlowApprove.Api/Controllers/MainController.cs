using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowApprove.Api.Controllers;

[Route("api")]
[ApiController]
public class MainController : BaseController
{
    public MainController()
    {
    }

    [HttpGet("v1/health")]
    public IActionResult HealthCheck()
    {
        return Ok("Service is running.");
    }
}
