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
        private readonly BookShopContext _Context;

        public BookService(BookShopContext bookShopContext)
        {
            _Context = bookShopContext;
        }

        public bool Delete(Book book)
        {
            try
            {
                _Context.Books.Remove(book);
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
                _Context.Remove(_Context.Books.Find(bookId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Book FirstOrDefault(Expression<Func<Book, bool>> filter)
        {
            IQueryable<Book> query = _Context.Books.Where(filter).Include(x => x.Authors);

            return query.FirstOrDefault();
        }

        public Book Get(int bookId)
        {
            return _Context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _Context.Books.Include(x => x.Authors);
        }

        //public IEnumerable<Author> GetAuthors(int id)
        //{
        //    return _Context.Authors.Where(x=>x.Id==id);
        //}

        public IEnumerable<Book> GetLastBooks(int count)
        {
            return _Context.Books.OrderByDescending(s => s.AddDate).Take(count);
        }

        public bool Insert(Book book)
        {
            try
            {
                _Context.Books.Add(book);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public bool Update(Book book)
        {
            try
            {
                _Context.Books.Update(book);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
