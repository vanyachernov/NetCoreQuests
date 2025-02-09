using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Root;

namespace Quests.Infrastructure.Configurations;

public class TestConfiguration : IEntityTypeConfiguration<Test>
{
    public void Configure(EntityTypeBuilder<Test> builder)
    {
        builder.ToTable("tests");

        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Id)
            .HasConversion(
                id => id.Value, 
                value => TestId.Create(value));
        
        builder
            .Property(t => t.UserId)
            .HasConversion(
                id => id.Value, 
                value => UserId.Create(value));
        
        builder.OwnsOne(t => t.Title, title =>
        {
            title
                .Property(t => t.Value)
                .HasColumnName("title")
                .IsRequired();
        });
        
        builder.OwnsOne(t => t.Description, description =>
        {
            description
                .Property(d => d.Value)
                .HasColumnName("description")
                .IsRequired();
        });
        
        builder.OwnsOne(t => t.Difficulty, difficulty =>
        {
            difficulty.Property(d => d.Value)
                .HasColumnName("difficulty")
                .IsRequired();
        });
        
        builder.OwnsOne(t => t.CreatedAt, createdAt =>
        {
            createdAt
                .Property(c => c.Value)
                .HasColumnName("created_at")
                .IsRequired();
        });
        
        builder.OwnsOne(t => t.UpdatedAt, updatedAt =>
        {
            updatedAt
                .Property(u => u.Value)
                .HasColumnName("updated_at")
                .IsRequired();
        });
        
        builder.HasMany(t => t.Questions)
            .WithOne()
            .HasForeignKey("TestId")
            .OnDelete(DeleteBehavior.Cascade);
    }
}