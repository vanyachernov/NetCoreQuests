using CSharpFunctionalExtensions;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Root;
using Quests.Domain.TestDirectory.ValueObjects;

namespace Quests.Application.TestDirectory.AddTest;

public class AddTestHandler(ITestsRepository testsRepository)
{
    public async Task<Result<Guid, Error>> Handle(
        AddTestRequest request,
        CancellationToken cancellationToken = default)
    {
        var newTestId = TestId.Create(Guid.NewGuid());
        
        var newUserId = UserId.Create(Guid.NewGuid());

        var titleResult = Title.Create(request.Title);
        
        if (titleResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Title creating error.");
        }

        var descriptionResult = Description.Create(request.Description);
        
        if (descriptionResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Description creating error.");
        }

        if (!Enum.TryParse(request.Difficulty, ignoreCase: true, out Difficulties difficultyEnum))
        {
            return Errors.General.ValueIsInvalid("Invalid difficulty value.");
        }

        var difficultyResult = Difficulty.Create(difficultyEnum);
        
        if (difficultyResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Difficulty creating error.");
        }
        
        var ratingResult = Rating.Create(request.Rating);
        
        if (ratingResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Rating creating error.");
        }

        var createdOrUpdateResult = CreatedOrUpdatedAt.Create(DateTime.UtcNow);

        var newTestResult = Test.Create(
            newTestId,
            titleResult.Value,
            descriptionResult.Value,
            newUserId,
            difficultyResult.Value,
            ratingResult.Value,
            createdOrUpdateResult.Value,
            createdOrUpdateResult.Value);

        if (newTestResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Test creating error.");
        }

        var newTestIdResult = await testsRepository.Add(
            newTestResult.Value, 
            cancellationToken);
        
        return newTestIdResult;
    }
}