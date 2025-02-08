namespace Quests.Domain.Shared.IDs;

public record TestResultId
{
    private TestResultId(Guid value) => Value = value;
    
    private Guid Value { get; }
    
    public static TestResultId NewId => new(Guid.NewGuid());

    public static TestResultId NewEmptyId => new(Guid.Empty);

    public static TestResultId Create(Guid id) => new(id);

    public static implicit operator Guid(TestResultId id) => id.Value; 
}