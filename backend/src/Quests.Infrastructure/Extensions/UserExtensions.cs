using Quests.Application.UserDirectory.AddUser;
using Quests.Domain.Shared.IDs;
using Quests.Infrastructure.Identity;

namespace Quests.Infrastructure.Extensions;

public static class UserExtensions
{
    public static UserId ToUserId(this ApplicationUser user)
        => UserId.Create(user.Id);

    public static Guid ToGuid(this UserId userId)
        => userId.Value;
    
    public static ApplicationUser ToApplicationUser(this AddUserRequest request)
    {
        if (request == null)
        {
            throw new ArgumentNullException(nameof(request));
        }

        return new ApplicationUser
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            UserName = request.Email
        };
    }
}