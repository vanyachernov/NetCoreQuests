namespace Quests.Application.TestDirectory.GetTests;

public class GetTestsResponse
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Difficulty { get; set; } = default!;
    public double Rating { get; set; }
    public IEnumerable<QuestionDto> Questions { get; set; } = default!;
}

public class QuestionDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = default!;
    public IEnumerable<OptionDto> Options { get; set; } = default!;
    public Guid? CorrectOptionId { get; set; }
}

public class OptionDto
{
    public Guid Id { get; set; }
    public string Text { get; set; } = default!;
    public bool IsCorrect { get; set; }
}