using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Description
{
    private Description(string value) => Value = value;

    public string Value { get; } = default!;

    public static Result<Description, Error> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description) || 
            description.Length > Constants.MAX_TITLE_DESCRIPTION_TEXT_LENGTH)
        {
            return Errors.General.ValueIsInvalid("Description is invalid!");
        }

        return new Description(description);
    }
};