using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quests.Application.TestDirectory.AddTest;
using Quests.Application.TestDirectory.GetTests;
using Quests.Infrastructure.Identity;

namespace Quests.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController(UserManager<ApplicationUser> userManager) 
    : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTests(
        [FromServices] GetTestsHandler testHandler,
        CancellationToken cancellationToken = default)
    {
        var tests = await testHandler.Handle(cancellationToken);
        
        return Ok(tests);
    }
    
    [HttpPost]
    [Route("{userId:guid}")]
    public async Task<ActionResult> Get(
        [FromRoute] Guid userId,
        [FromBody] AddTestRequest request,
        [FromServices] AddTestHandler testHandler,
        CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());
        
        if (user is null)
        {
            return NotFound($"User with ID {userId} not found.");
        }
        
        var newTestResult = await testHandler.Handle(
            user.Id,
            request,
            cancellationToken);
        
        return Ok(newTestResult.Value);
    }
}