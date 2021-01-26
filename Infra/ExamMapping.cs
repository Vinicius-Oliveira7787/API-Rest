using Domain.Exams;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class ExamMapping : IEntityTypeConfiguration<Exam> {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder
                .Property(exam => exam)
                .HasMaxLength(100);
                
        }
    }
}