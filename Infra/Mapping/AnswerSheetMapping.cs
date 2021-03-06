using Domain.AnswerSheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class AnswerSheetMapping : IEntityTypeConfiguration<AnswerSheet>
    {
        public void Configure(EntityTypeBuilder<AnswerSheet> builder)
        {
            builder
                .Property(answerSheet => answerSheet.Id)
                .IsRequired();
        }
    }
}