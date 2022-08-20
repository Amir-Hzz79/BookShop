using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        void Save();
    }
}
