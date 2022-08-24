using BookShop.DataLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataLayer
{
    public class BookShopContext : IdentityDbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }


        public BookShopContext()
        {

        }

        public BookShopContext(DbContextOptions<BookShopContext> options)
        : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            optionsBuilder.UseSqlServer("MainConnection");
            
        }
    }
}
