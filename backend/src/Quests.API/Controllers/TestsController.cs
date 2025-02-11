using Microsoft.AspNetCore.Mvc;
using Quests.Application.TestDirectory.AddTest;

namespace Quests.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Get(
        [FromBody] AddTestRequest request,
        [FromServices] AddTestHandler testHandler,
        CancellationToken cancellationToken = default)
    {
        var result = await testHandler.Handle(
            request,
            cancellationToken);
        
        return Ok(result);
    }
}