using CSharpFunctionalExtensions;
using Quests.Application.TestDirectory.GetTests;
using Quests.Domain.Shared;

namespace Quests.Application.TestDirectory.GetTestById;

public class GetTestByIdHandler(ITestsRepository testsRepository)
{
    public async Task<Result<GetTestsResponse, Error>> Handle(
        Guid testId, 
        CancellationToken cancellationToken = default)
    {
        var test = await testsRepository.GetTestByIdWithDetails(
            testId, 
            cancellationToken);

        if (test == null)
        {
            return Errors.General.NotFound(testId);
        }
        
        var testDto = new GetTestsResponse
        {
            Id = test.Id.Value,
            Title = test.Title.Value,
            Description = test.Description.Value,
            Difficulty = test.Difficulty.Value.ToString(),
            Rating = test.Rating.Value,
            Questions = test.Questions.Select(q => new QuestionDto
            {
                Id = q.Id.Value,
                Text = q.Text.Value,
                CorrectOptionId = q.CorrectOptionId?.Value,
                Options = q.Options.Select(o => new OptionDto
                {
                    Id = o.Id.Value,
                    Text = o.Text,
                    IsCorrect = o.IsCorrect
                }).ToList()
            }).ToList()
        };

        return testDto;
    }
}