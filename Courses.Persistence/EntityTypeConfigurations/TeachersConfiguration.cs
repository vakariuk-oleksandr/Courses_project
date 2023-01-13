using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.domain;

namespace Courses.Persistant
{
    public class TeachersConfiguration : IEntityTypeConfiguration<Teachers>
    {
        public void Configure(EntityTypeBuilder<Teachers> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.FullName).HasMaxLength(50).IsRequired();
            builder.Property(note => note.SpecializationID).HasMaxLength(50).IsRequired();
            builder.Property(note => note.City).HasMaxLength(50).IsRequired();
            builder.Property(note => note.Phonenumb).HasMaxLength(14);
        }
    }
}
