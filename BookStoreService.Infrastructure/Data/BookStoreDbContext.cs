
using BookStoreService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStoreService.Infrastructure.Data
{
    public class BookStoreDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = Guid.Parse("1e209cbf-5175-4205-89cb-0cd33ea24987"), Title = "1984", Author = "George Orwell" },
                new Book { Id = Guid.Parse("cfe0191a-bde6-4b6c-8bd3-d097cf557043"), Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" }
            );
        }
    }
}
