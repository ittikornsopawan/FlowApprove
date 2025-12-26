using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowApprove.Api.Controllers;

[Route("api/workflow")]
[ApiController]
public class WorkflowController : BaseController
{
    public WorkflowController()
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetWorkflow()
    {
        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWorkflowById(Guid id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> CreateWorkflow()
    {
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateWorkflow()
    {
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkflow()
    {
        return Ok();
    }
}
