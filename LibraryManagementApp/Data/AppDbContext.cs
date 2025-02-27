using LibraryManagementApp.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

         


            modelBuilder.Entity<Books>().HasData(
                new Books { Id = "1", Title = "The Mahabharata", Author = "Ramesh Menon", ISBN = "978-8129115356", CopiesAvailable = 25, BorrowCount = 8 },
                new Books { Id = "2", Title = "The Ramayana: A Modern Retelling", Author = "Ramesh Menon", ISBN = "978-0312428032", CopiesAvailable = 30, BorrowCount = 10 },
                new Books { Id = "3", Title = "Shivaji: The Great Maratha", Author = "Ranjit Desai", ISBN = "978-8172241215", CopiesAvailable = 20, BorrowCount = 15 },
                new Books { Id = "4", Title = "Swami", Author = "Ranjit Desai", ISBN = "978-8177667843", CopiesAvailable = 25, BorrowCount = 12 },
                new Books { Id = "5", Title = "Radheya", Author = "Ranjit Desai", ISBN = "978-8177661018", CopiesAvailable = 45, BorrowCount = 8 },
                new Books { Id = "6", Title = "Partner", Author = " V. P. Kale", ISBN = "978-8184981073", CopiesAvailable = 35, BorrowCount = 55 },
                new Books { Id = "7", Title = "Vapurza", Author = " V. P. Kale", ISBN = "978-8177665153", CopiesAvailable = 15, BorrowCount = 16 }
                );
        }
    }
}
