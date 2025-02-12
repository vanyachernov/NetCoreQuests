namespace Quests.Application.DTOs;

public record QuestionDto
{
    public string Text { get; set; }
    public List<OptionDto> Options { get; set; }
}