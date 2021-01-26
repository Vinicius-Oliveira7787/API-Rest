using Domain.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra {
    public class PlayerMapping : IEntityTypeConfiguration<Student> {
        public void Configure(EntityTypeBuilder<Student> builder) {
            builder
                .Property(student => student)
                .HasMaxLength(100);
        }
    }
}