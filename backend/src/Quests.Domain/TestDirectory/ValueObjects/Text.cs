using CSharpFunctionalExtensions;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Text
{
    private Text(string value) => Value = value;

    public string Value { get; }
    
    public static Result<Text> Create(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return Result.Failure<Text>("Text cannot be empty.");
        }

        return new Text(text);
    }

    public override string ToString() => Value;
}