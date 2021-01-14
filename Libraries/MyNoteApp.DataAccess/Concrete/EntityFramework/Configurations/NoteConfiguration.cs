using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNotePad.Entities.Entities;

namespace MyNoteApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class NoteConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.ToTable("Notes");
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.NoteTitle).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NoteContent).IsRequired();
            builder.Property(p => p.CreatedDateTime).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValueSql("0");

            // Relationships

            builder.HasOne(p => p.CreatedByUser).WithMany(p => p.Notes).HasForeignKey(p => p.CreatedByUserId);
        }
    }
}
