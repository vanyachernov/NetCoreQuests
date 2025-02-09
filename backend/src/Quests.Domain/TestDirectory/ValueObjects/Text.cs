using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Text
{
    private Text(string value) => Value = value;

    public string Value { get; }
    
    public static Result<Text, Error> Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Errors.General.ValueIsInvalid("Text cannot be empty.");
        }

        return new Text(text);
    }

    public override string ToString() => Value;
}