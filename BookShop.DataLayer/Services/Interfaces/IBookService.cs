using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public interface IBookService
    {
        bool Insert(Book book);

        bool Update(Book book);

        bool Delete(Book book);

        bool Delete(int bookId);

        Book Get(int bookId);

        IEnumerable<Book> GetAll();

        IEnumerable<string> GetAllNames();

        //IEnumerable<string> GetAuthorsName(int id);

        Book FirstOrDefault(Expression<Func<Book, bool>> filter);

        void Save();

        IEnumerable<Book> GetLastBooks(int count);
    }
}
