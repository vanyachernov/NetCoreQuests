using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;
using Quests.Domain.TestDirectory.Entities;

namespace Quests.Infrastructure.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.ToTable("questions");
        
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Id)
            .HasConversion(
                id => id.Value,
                value => QuestionId.Create(value))
            .HasColumnName("question_id")
            .IsRequired();
        
        builder.OwnsOne(q => q.Text, text =>
        {
            text.Property(t => t.Value)
                .HasColumnName("text")
                .HasMaxLength(Constants.MAX_OPTION_TEXT_LENGTH)
                .IsRequired();
        });
        
        builder.HasMany(q => q.Options)
            .WithOne(o => o.Question)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property<OptionId?>("CorrectOptionId")
            .HasColumnName("correct_option_id");
        
        builder.HasOne<Option>()
            .WithMany()
            .HasForeignKey("CorrectOptionId")
            .OnDelete(DeleteBehavior.Restrict);
    }
}