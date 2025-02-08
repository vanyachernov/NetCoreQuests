using CSharpFunctionalExtensions;

namespace Quests.Domain.TestDirectory.ValueObjects;

public record CreatedOrUpdatedAt
{
    private CreatedOrUpdatedAt(DateTime value) => Value = value;

    public DateTime Value { get; }
    
    public static Result<CreatedOrUpdatedAt> Create(DateTime createdAt)
    {
        if (createdAt < new DateTime(2000, 1, 1))
        {
            return Result.Failure<CreatedOrUpdatedAt>("Created date cannot be earlier than January 1, 2000.");
        }

        if (createdAt > DateTime.UtcNow)
        {
            return Result.Failure<CreatedOrUpdatedAt>("Created date cannot be in the future.");
        }
        
        return new CreatedOrUpdatedAt(createdAt);
    }
    
    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}