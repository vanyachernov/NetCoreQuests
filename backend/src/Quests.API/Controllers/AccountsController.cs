using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quests.Application.UserDirectory.AddUser;
using Quests.Infrastructure.Extensions;
using Quests.Infrastructure.Identity;

namespace Quests.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController(UserManager<ApplicationUser> userManager) 
    : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(
        [FromBody] AddUserRequest request,
        CancellationToken cancellationToken = default)
    {
        if (request is null)
        {
            return BadRequest();
        }

        var user = request.ToApplicationUser();
        
        var result = await userManager.CreateAsync(
            user, 
            request.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors
                .Select(e => e.Description);

            return BadRequest(
                new AddUserResponse
                {
                    Errors = errors
                });
        }

        return StatusCode(201);
    }
}