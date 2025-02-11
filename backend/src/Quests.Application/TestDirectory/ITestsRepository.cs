using CSharpFunctionalExtensions;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Root;

namespace Quests.Application.TestDirectory;

public interface ITestsRepository
{
    Task<Result<Guid, Error>> Add(
        Test test, 
        CancellationToken cancellationToken = default);
    
    Task SetCorrectOptionId(
        QuestionId questionId, 
        OptionId correctOptionId, 
        CancellationToken cancellationToken = default);

    Task<IEnumerable<Test>> GetAllTestsWithDetails(
        CancellationToken cancellationToken = default);
}