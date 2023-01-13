using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.domain;

namespace Courses.Persistant
{
    public class SpecConfiguration : IEntityTypeConfiguration<Specialization>
    {
        public void Configure(EntityTypeBuilder<Specialization> builder)
        {
            builder.HasKey(note => note.SpecializationID);
            builder.HasIndex(note => note.SpecializationID).IsUnique();
            builder.Property(note => note.Predmetna_obl).HasMaxLength(50).IsRequired();
            builder.Property(note => note.TeachersID).HasMaxLength(50).IsRequired();
        }
    }
}
