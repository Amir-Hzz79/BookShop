using BookShop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.DataLayer
{
    public class BookShopContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }


        public BookShopContext(DbContextOptions<BookShopContext> dbContextOptions) : base(dbContextOptions)
        {
                
        }
    }
}
