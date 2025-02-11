using Quests.Domain.TestDirectory.Root;

namespace Quests.Application.TestDirectory;

public interface ITestsRepository
{
    /// <summary>
    /// Creates a new test.
    /// </summary>
    /// <param name="test"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Guid> Add(
        Test test,
        CancellationToken cancellationToken = default);
}