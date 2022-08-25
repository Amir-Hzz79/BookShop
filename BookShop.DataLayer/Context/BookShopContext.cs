using BookShop.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataLayer
{
    public class BookShopContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        //public DbSet<RefreshToken> UserRefreshTokens { get; set; }

        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
        : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("MainConnection");

        }
    }
}
