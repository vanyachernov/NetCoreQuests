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
        
        builder.OwnsOne(q => q.CorrectOption, correctOption =>
        {
            correctOption.Property(o => o.Id)
                .HasColumnName("correct_option_id")
                .IsRequired();

            correctOption.Property(o => o.Text)
                .HasColumnName("correct_option_text")
                .HasMaxLength(Constants.MAX_OPTION_TEXT_LENGTH)
                .IsRequired();

            correctOption.Property(o => o.IsCorrect)
                .HasColumnName("is_correct")
                .IsRequired();
        });
        
        builder.OwnsMany(q => q.Options, options =>
        {
            options.WithOwner().HasForeignKey("QuestionId");

            options.Property(o => o.Id)
                .HasColumnName("option_id")
                .IsRequired();

            options.Property(o => o.Text)
                .HasColumnName("option_text")
                .HasMaxLength(Constants.MAX_OPTION_TEXT_LENGTH)
                .IsRequired();

            options.Property(o => o.IsCorrect)
                .HasColumnName("is_correct")
                .IsRequired();

            options.ToTable("options");
        });
    }
}