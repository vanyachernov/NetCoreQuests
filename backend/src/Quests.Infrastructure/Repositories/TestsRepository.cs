using Quests.Application.TestDirectory;
using Quests.Domain.TestDirectory.Root;

namespace Quests.Infrastructure.Repositories;

public class TestsRepository(QuestDbContext context) : ITestsRepository
{
    public async Task<Guid> Add(
        Test test, 
        CancellationToken cancellationToken = default)
    {
        await context.AddAsync(
            test, 
            cancellationToken);

        await context.SaveChangesAsync(cancellationToken);

        return test.Id.Value;
    }
}