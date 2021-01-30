using Domain.ApprovedStudents;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra
{
    public class ApprovedStudentMapping : IEntityTypeConfiguration<ApprovedStudent>
    {
        public void Configure(EntityTypeBuilder<ApprovedStudent> builder)
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5("admin123");

            builder
                .Property(student => student.Score)
                .IsRequired();
        }
    }
}