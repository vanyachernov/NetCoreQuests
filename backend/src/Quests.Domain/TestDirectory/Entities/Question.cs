using Quests.Domain.Shared.IDs;

namespace Quests.Domain.TestDirectory.Entities;

public class Question : Shared.Entity<QuestionId>
{
    public Question(QuestionId id) : base(id) { }
    
    
}