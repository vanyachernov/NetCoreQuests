using CSharpFunctionalExtensions;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Entities;

public class Option : Quests.Domain.Shared.Entity<OptionId>
{
    private Option(OptionId id) : base(id) { }
    
    public Option(
        OptionId id,
        string text,
        bool isCorrect) : base(id)
    {
        Text = text;
        IsCorrect = isCorrect;
    }
    
    public string Text { get; private set; }
    public bool IsCorrect { get; private set; }

    public QuestionId QuestionId { get; set; }
    public Question Question { get; private set; } = null!;

    public static Result<Option, Error> Create(
        string text, 
        bool isCorrect)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Errors.General.ValueIsInvalid("Option text cannot be empty.");
        }

        if (text.Length > Constants.MAX_OPTION_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid($"Option text exceeds the maximum length characters.");
        }

        var option = new Option(
            OptionId.NewId, 
            text, 
            isCorrect);
        
        return option;
    }
}