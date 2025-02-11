using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.ValueObjects;

namespace Quests.Domain.TestDirectory.Entities;

public class Question : Entity<QuestionId>
{
    private readonly List<Option> _options = [];
    
    public Question(QuestionId id)
        : base(id) { }
    
    public Question(
        QuestionId id,
        Text text,
        IEnumerable<Option> options)
        : base(id)
    {
        Text = text;
        foreach (var option in options)
        {
            AddOption(option);
        }
    }

    public Text Text { get; private set; } = default!;
    public OptionId? CorrectOptionId { get; set; }
    public IReadOnlyCollection<Option> Options => _options.AsReadOnly();

    public void AddOption(Option option)
    {
        if (_options.Any(o => o.Id == option.Id))
        {
            return;
        }
        option.QuestionId = this.Id;
        _options.Add(option);
    }

    public void SetCorrectOption(Option? option)
    {
        if (option != null)
        {
            CorrectOptionId = option.Id; 
        }
        else
        {
            CorrectOptionId = null;
        }
    }
}