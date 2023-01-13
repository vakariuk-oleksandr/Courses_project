using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.domain;

namespace Courses.Persistant
{
    public class FormConfiguration : IEntityTypeConfiguration<Studyingform>
    {
        public void Configure(EntityTypeBuilder<Studyingform> builder)
        {
            builder.HasKey(note => note.Id);
            builder.HasIndex(note => note.Id).IsUnique();
            builder.Property(note => note.Form).HasMaxLength(26).IsRequired();
            builder.Property(note => note.TeacherId).HasMaxLength(30).IsRequired();
            builder.Property(note => note.StudentId).HasMaxLength(30).IsRequired();
        }
    }
}
