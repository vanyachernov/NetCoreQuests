using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Quests.Application.UserDirectory.AddUser;
using Quests.Application.UserDirectory.AuthenticateUser;
using Quests.Domain.Shared;
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
    
    [HttpPost("authenticate")]
    public async Task<ActionResult<Result<Error>>> Authenticate(
        [FromBody] AuthenticateUserRequest request,
        [FromServices] JwtHandler jwtHandler,
        CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByEmailAsync(request.Email!);

        if (user is null || !await userManager.CheckPasswordAsync(
                user, 
                request.Password!))
        {
            return Unauthorized(new AuthenticateUserResponse
            {
                ErrorMessage = "Invalid Authentication"
            });
        }

        var tokenResult = await jwtHandler.CreateToken(
            user, 
            populateExp: true);

        if (tokenResult.IsFailure)
        {
            Errors.General.ValueIsInvalid("Token");
        }

        return Ok(tokenResult.Value);
    }
}