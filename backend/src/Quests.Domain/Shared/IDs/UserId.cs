namespace Quests.Domain.Shared.IDs;

public record UserId
{
    private UserId(Guid value) => Value = value;
    
    public Guid Value { get; }
    
    public static UserId NewId => new(Guid.NewGuid());

    public static UserId NewEmptyId => new(Guid.Empty);

    public static UserId Create(Guid id) => new(id);

    public static implicit operator Guid(UserId id) => id.Value; 
}