using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Book Get(int bookId)
        {
            return _Context.Books.Find(bookId);
        }

        public IEnumerable<Book> GetAll()
        {
            return _Context.Books;
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
