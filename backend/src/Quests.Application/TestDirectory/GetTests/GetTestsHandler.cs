namespace Quests.Application.TestDirectory.GetTests;

public class GetTestsHandler(ITestsRepository testsRepository)
{
    public async Task<IEnumerable<GetTestsResponse>> Handle(
        CancellationToken cancellationToken = default)
    {
        var tests = await testsRepository.GetAllTestsWithDetails(cancellationToken);

        return tests.Select(t => new GetTestsResponse
        {
            Id = t.Id.Value,
            Title = t.Title.Value,
            Description = t.Description.Value,
            Difficulty = t.Difficulty.Value.ToString(),
            Rating = t.Rating.Value,
            Questions = t.Questions.Select(q => new QuestionDto
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
        }).ToList();
    }
}