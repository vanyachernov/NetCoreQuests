using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record Difficulty
{
    private Difficulty(Difficulties value) => Value = value;

    public Difficulties Value { get; }

    public static Result<Difficulty> Create(Difficulties difficulty)
    {
        return new Difficulty(difficulty);
    }
}