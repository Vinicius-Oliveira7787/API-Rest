using Domain.AswerExams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class AswerExamsMapping : IEntityTypeConfiguration<AswerExam> {
        public void Configure(EntityTypeBuilder<AswerExam> builder)
        {
            builder
                .Property(exam => exam.Questions)
                .IsRequired();
        }
    }
}