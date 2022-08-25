using BookShop.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public class BookService : IBookService
    {
        private readonly BookShopContext _context;

        public BookService(BookShopContext bookShopContext)
        {
            _context = bookShopContext;
        }

        public bool Delete(Book book)
        {
            try
            {
                _context.Books.Remove(book);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int bookId)
        {
            try
            {
                _context.Books.Remove(_context.Books.Find(bookId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Book FirstOrDefault(Expression<Func<Book, bool>> filter)
        {
            IQueryable<Book> query = _context.Books.Where(filter).Include(x => x.Authors);

            return query.FirstOrDefault();
        }

        public Book Get(int bookId)
        {
            return _context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(x => x.Authors);
        }

        public IEnumerable<string> GetAllNames()
        {
            return _context.Books.Select(x => x.Name);
        }

        //public IEnumerable<string> GetAuthorsName(int id)
        //{
        //    return _Context.Books.Select(_Context.Books.Find(id).Name);
        //}

        public IEnumerable<Book> GetLastBooks(int count)
        {
            return _context.Books.OrderByDescending(s => s.AddDate).Take(count);
        }

        public bool Insert(Book book)
        {
            try
            {
                _context.Books.Add(book);
               //book.Authors.Add
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

        public bool Update(Book book)
        {
            try
            {
                _context.Books.Update(book);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
