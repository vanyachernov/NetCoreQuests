using CSharpFunctionalExtensions;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Entities;
using Quests.Domain.TestDirectory.Root;
using Quests.Domain.TestDirectory.ValueObjects;

namespace Quests.Application.TestDirectory.AddTest;

public class AddTestHandler(ITestsRepository testsRepository)
{
    public async Task<Result<Guid, Error>> Handle(
        Guid userId,
        AddTestRequest request,
        CancellationToken cancellationToken = default)
    {
        var newTestId = TestId.Create(Guid.NewGuid());
        
        var existsUser = UserId.Create(userId);

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
        
        var newTestResult = Test.Create(
            newTestId,
            titleResult.Value,
            descriptionResult.Value,
            existsUser,
            difficultyResult.Value,
            ratingResult.Value);

        if (newTestResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Test creating error.");
        }

        var newTest = newTestResult.Value;

        foreach (var questionDto in request.Questions)
        {
            var textResult = Text.Create(questionDto.Text);
            
            if (textResult.IsFailure)
            {
                return Errors.General.ValueIsInvalid($"Invalid question text: {questionDto.Text}");
            }
            
            var questionId = QuestionId.Create(Guid.NewGuid());
            
            var options = new List<Option>();
        
            foreach (var optionDto in questionDto.Options)
            {
                var optionResult = Option.Create(optionDto.Text, optionDto.IsCorrect);
                
                if (optionResult.IsFailure)
                {
                    return Errors.General.ValueIsInvalid($"Invalid option text: {optionDto.Text}");
                }
                
                options.Add(optionResult.Value);
            }

            var question = new Question(questionId, textResult.Value, options);
            
            newTest.AddQuestion(question);
        }
        
        var newTestIdResult = await testsRepository.Add(newTest, cancellationToken);
        
        if (newTestIdResult.IsFailure)
        {
            return Errors.General.ValueIsInvalid("Failed to add test.");
        }
        
        foreach (var question in newTest.Questions)
        {
            var correctOption = question.Options.FirstOrDefault(o => o.IsCorrect);
            
            if (correctOption != null)
            {
                await testsRepository.SetCorrectOptionId(question.Id, correctOption.Id, cancellationToken);
            }
        }
        
        return newTestIdResult;
    }
}