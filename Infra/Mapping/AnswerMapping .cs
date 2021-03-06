using Domain.Answers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class AnswerMapping : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder
                .Property(answerSheet => answerSheet.Score)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(answerSheet => answerSheet.AnswerSheetId)
                .IsRequired();
            
            builder
                .Property(answerSheet => answerSheet.Id)
                .IsRequired();
        }
    }
}