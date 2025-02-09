using Quests.Domain.Shared.IDs;
using Quests.Infrastructure.Identity;

namespace Quests.Infrastructure.Extensions;

public static class UserExtensions
{
    public static UserId ToUserId(this ApplicationUser user)
        => UserId.Create(user.Id);

    public static Guid ToGuid(this UserId userId)
        => userId.Value;
}