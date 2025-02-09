using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public class CorrectOption
{
    private CorrectOption(
        Guid id, 
        string text)
    {
        Id = id;
        Text = text;
    }

    public Guid Id { get; }
    public string Text { get; }

    public static Result<CorrectOption, Error> Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Errors.General.ValueIsInvalid("Correct option text cannot be empty.");
        }
        
        return new CorrectOption(
            Guid.NewGuid(), 
            text);
    }

    public override string ToString() => Text;
}