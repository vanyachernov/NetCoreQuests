using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quests.Domain.TestDirectory.Entities;
using Quests.Domain.TestDirectory.Root;
using Quests.Infrastructure.Identity;

namespace Quests.Infrastructure;

public class QuestDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public QuestDbContext(DbContextOptions<QuestDbContext> options)
        : base(options) { }
    
    public DbSet<Test> Tests { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfigurationsFromAssembly(typeof(QuestDbContext).Assembly);
    }
}