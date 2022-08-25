

using BookShop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShop.DataLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopContext _context;

        public AuthorService(BookShopContext bookShopContext)
        {
            _context = bookShopContext;
        }

        public bool Delete(Author author)
        {
            try
            {
                _context.Authors.Remove(author);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int authorId)
        {
            try
            {
                _context.Remove(_context.Authors.Find(authorId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Author FirstOrDefault(Expression<Func<Author, bool>> filter)
        {
            IQueryable<Author> query = _context.Authors.Where(filter).Include(x => x.Books);

            return query.FirstOrDefault();
        }

        public Author Get(int authorId)
        {
            return _context.Authors.Find(authorId);
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.Include(x => x.Books);
        }

        public IEnumerable<string> GetAllNames()
        {
            return _context.Authors.Select(x => x.Name);
        }
        //public IEnumerable<Book> GetBooks(int id)
        //{
        //    return _Context.Books.Where(x=>x.Id==id);
        //}

        public bool Insert(Author author)
        {
            try
            {
                _context.Authors.Add(author);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Author author)
        {
            try
            {
                _context.Authors.Update(author);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
