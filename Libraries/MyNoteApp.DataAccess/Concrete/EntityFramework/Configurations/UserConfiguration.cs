using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyNotePad.Entities.Entities;

namespace MyNoteApp.DataAccess.Concrete.EntityFramework.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Username).IsRequired().HasMaxLength(30);
            builder.Property(p => p.PasswordHashed).IsRequired().HasMaxLength(40);
            builder.Property(p => p.CreatedDateTime).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDeleted).IsRequired().HasDefaultValueSql("0");
        }
    }
}
