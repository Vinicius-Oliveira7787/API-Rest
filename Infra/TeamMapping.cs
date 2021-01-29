using Domain.AnswerSheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class TeamMapping : IEntityTypeConfiguration<AnswerSheet>
    {
        public void Configure(EntityTypeBuilder<AnswerSheet> builder)
        {
            builder
                .Property(answerSheet => answerSheet.Title)
                .IsRequired()
                .HasMaxLength(80);
        }
    }
}