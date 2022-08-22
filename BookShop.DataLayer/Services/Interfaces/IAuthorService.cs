using BookShop.DataLayer.Models;
using System.Linq.Expressions;

namespace BookShop.DataLayer.Services
{
    public interface IAuthorService
    {
        bool Insert(Author author);

        bool Update(Author author);

        bool Delete(Author author);

        bool Delete(int authorId);

        Author Get(int authorId);

        IEnumerable<Author> GetAll();

        IEnumerable<string> GetAllNames();

        //IEnumerable<Book> GetBooks(int id);

        Author FirstOrDefault(Expression<Func<Author, bool>> filter);

        void Save();
    }
}
