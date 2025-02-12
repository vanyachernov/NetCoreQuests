namespace Quests.Domain.Shared.IDs;

public class OptionId
{
    private OptionId(Guid value) => Value = value;
    
    public Guid Value { get; }
    
    public static OptionId NewId => new(Guid.NewGuid());

    public static OptionId NewEmptyId => new(Guid.Empty);

    public static OptionId Create(Guid id) => new(id);

    public static implicit operator Guid(OptionId id) => id.Value;
}