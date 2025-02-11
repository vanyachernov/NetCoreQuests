using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Quests.Application.TestDirectory;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Root;

namespace Quests.Infrastructure.Repositories;

public class TestsRepository(QuestDbContext dbContext) : ITestsRepository
{
    public async Task<Result<Guid, Error>> Add(
        Test test, 
        CancellationToken cancellationToken = default)
    {
        try
        {
            dbContext.Tests.Add(test);
            
            await dbContext.SaveChangesAsync(cancellationToken);
            
            return test.Id.Value;
        }
        catch (Exception ex)
        {
            return Errors.General.ValueIsInvalid(ex.Message);
        }
    }

    public async Task SetCorrectOptionId(
        QuestionId questionId, 
        OptionId correctOptionId, 
        CancellationToken cancellationToken = default)
    {
        var question = await dbContext.Questions.FindAsync(new object[] { questionId }, cancellationToken);
        if (question != null)
        {
            question.CorrectOptionId = correctOptionId;
            
            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
    
    public async Task<IEnumerable<Test>> GetAllTestsWithDetails(
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Tests
            .Include(t => t.Questions)
                .ThenInclude(q => q.Options)
            .ToListAsync(cancellationToken);
    }

    public async Task<Test?> GetTestByIdWithDetails(
        Guid testId, 
        CancellationToken cancellationToken = default)
    {
        return await dbContext.Tests
            .Include(t => t.Questions)
            .ThenInclude(q => q.Options)
            .FirstOrDefaultAsync(t => t.Id == testId, cancellationToken);
    }
}