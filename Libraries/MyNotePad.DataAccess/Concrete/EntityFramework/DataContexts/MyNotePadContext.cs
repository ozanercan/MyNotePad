using Microsoft.EntityFrameworkCore;
using MyNotePad.Entities.Entities;
using System.Reflection;

namespace MyNotePad.DataAccess.Concrete.EntityFramework.DataContexts
{
    public class MyNotePadContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-ENNG9DE\SQLEXPRESS;Database=myNotePadDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Note> Notes { get; set; }
    }
}
