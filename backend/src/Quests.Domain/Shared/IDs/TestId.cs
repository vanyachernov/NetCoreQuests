namespace Quests.Domain.Shared.IDs;

public record TestId
{
    private Guid Value { get; }
    
    private TestId(Guid value) => Value = value;
    
    public static TestId Create(Guid id) => new(id);
    
    public static TestId NewId => new(Guid.NewGuid());

    public static implicit operator Guid(TestId id) => id.Value;
}