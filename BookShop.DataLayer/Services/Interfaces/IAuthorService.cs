using BookShop.DataLayer.Models;

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

        void Save();
    }
}
