using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quests.Domain.Shared;
using Quests.Domain.Shared.IDs;

public class OptionConfiguration : IEntityTypeConfiguration<Option>
{
    public void Configure(EntityTypeBuilder<Option> builder)
    {
        builder.ToTable("options");
        
        builder.HasKey(o => o.Id);
        builder.Property(o => o.Id)
            .HasConversion(
                id => id.Value,
                value => OptionId.Create(value))
            .HasColumnName("option_id")
            .IsRequired();
        
        builder.Property(o => o.QuestionId)
            .HasConversion(
                id => id.Value,
                value => QuestionId.Create(value))
            .HasColumnName("question_id")
            .IsRequired();

        builder.HasOne(o => o.Question)
            .WithMany(q => q.Options)
            .HasForeignKey(o => o.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(o => o.Text)
            .HasColumnName("text")
            .HasMaxLength(Constants.MAX_OPTION_TEXT_LENGTH)
            .IsRequired();

        builder.Property(o => o.IsCorrect)
            .HasColumnName("is_correct")
            .IsRequired();
    }
}