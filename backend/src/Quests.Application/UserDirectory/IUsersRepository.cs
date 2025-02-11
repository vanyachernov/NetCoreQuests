namespace Quests.Application.UserDirectory;

public interface IUsersRepository
{
    Task<Guid> Add(CancellationToken cancellationToken = default);
}