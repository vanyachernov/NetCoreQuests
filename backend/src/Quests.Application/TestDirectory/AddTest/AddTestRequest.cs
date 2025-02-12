using Quests.Application.DTOs;

namespace Quests.Application.TestDirectory.AddTest;

public class AddTestRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Difficulty { get; set; }
    public double Rating { get; set; }
    public List<QuestionDto> Questions { get; set; }
}