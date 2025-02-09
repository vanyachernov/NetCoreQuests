using System.Net.Mime;
using CSharpFunctionalExtensions;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.ValueObjects;

namespace Quests.Domain.TestDirectory.Entities;

public class Question : Shared.Entity<QuestionId>
{
    private readonly List<Option> _options = [];

    public Question(
        QuestionId id,
        Text text,
        Option correctOption)
        : base(id)
    {
        Text = text;
        CorrectOption = correctOption;
        
        _options.Add(correctOption);
    }

    public Text Text { get; private set; } = default!;
    public Option CorrectOption { get; private set; } = default!;
    public IReadOnlyCollection<Option> Options => _options.AsReadOnly();

    public void AddOption(Option option)
    {
        if (_options.Any(o => o.Id == option.Id))
        {
            return;
        }

        _options.Add(option);
    }

    public void SetCorrectOption(Option option)
    {
        if (!_options.Contains(option))
        {
            return;
        }

        CorrectOption = option;
    }
}