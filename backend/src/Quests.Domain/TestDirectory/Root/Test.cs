using CSharpFunctionalExtensions;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Entities;
using Quests.Domain.TestDirectory.ValueObjects;

namespace Quests.Domain.TestDirectory.Root;

public class Test : Shared.Entity<TestId>
{
    public Test(TestId id)
        : base(id) { }
    
    private readonly List<Question> _questions = [];

    public Test(
        TestId id,
        Title title,
        Description description,
        UserId userId,
        Difficulty difficulty,
        Rating rating) : base(id)
    {
        Title = title;
        Description = description;
        UserId = userId;
        Difficulty = difficulty;
        Rating = rating;
    }

    public Title Title { get; private set; } = default!;
    public Description Description { get; private set; } = default!;
    public UserId UserId { get; private set; } = default!;
    public Difficulty Difficulty { get; private set; } = default!;
    public Rating Rating { get; private set; } = default!;
    
    public IReadOnlyCollection<Question> Questions => _questions;
    
    public void AddQuestion(Question question) 
        => _questions.Add(question);

    public static Result<Test, Error> Create(
        TestId id,
        Title title,
        Description description,
        UserId userId,
        Difficulty difficulty,
        Rating rating)
    {
        return new Test(
            id,
            title,
            description,
            userId,
            difficulty,
            rating);
    }
}