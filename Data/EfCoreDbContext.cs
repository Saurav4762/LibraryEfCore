using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using EfCoreDbContext.Entities;

namespace EfCoreDbContext.Data
{
    public class EfCoreDbcontext : DbContext
    {
        public EfCoreDbcontext(DbContextOptions<EfCoreDbcontext> options) : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Member> Members { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Author>().ToTable("Student");
        }
    }
    
}