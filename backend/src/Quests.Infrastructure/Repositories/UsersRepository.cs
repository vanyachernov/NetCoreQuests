using Quests.Application.UserDirectory;

namespace Quests.Infrastructure.Repositories;

public class UsersRepository : IUsersRepository
{
    public Task<Guid> Add(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}