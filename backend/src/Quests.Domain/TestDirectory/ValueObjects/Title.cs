using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Title
{
    private Title(string value) => Value = value;

    public string Value { get; } = default!;

    public static Result<Title, Error> Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title) || title.Length > Constants.MAX_TITLE_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Title is invalid!");
        }

        return new Title(title);
    }
};