using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Option
{
    private Option(
        Guid id, 
        string text, 
        bool isCorrect)
    {
        Id = id;
        Text = text;
        IsCorrect = isCorrect;
    }

    public Guid Id { get; }
    public string Text { get; }
    public bool IsCorrect { get; }
    
    public static Result<Option> Create(
        string text, 
        bool isCorrect)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Result.Failure<Option>("Option text cannot be empty.");
        }
        
        return new Option(
            Guid.NewGuid(), 
            text, 
            isCorrect);
    }
    
    public override string ToString() => Text;
}