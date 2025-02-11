using CSharpFunctionalExtensions;
using Quests.Domain.Shared;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record CreatedOrUpdatedAt
{
    public DateTime Value { get; }

    private CreatedOrUpdatedAt(DateTime value) => Value = value;

    public static CreatedOrUpdatedAt Create(DateTime value) => new(value);
}