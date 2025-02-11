using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quests.Application.TestDirectory.AddTest;
using Quests.Infrastructure.Identity;

namespace Quests.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestsController(UserManager<ApplicationUser> userManager) 
    : ControllerBase
{
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