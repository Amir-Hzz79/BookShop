

using BookShop.DataLayer.Models;
using System.Linq.Expressions;

namespace BookShop.DataLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookShopContext _Context;

        public AuthorService(BookShopContext bookShopContext)
        {
            _Context = bookShopContext;
        }

        public bool Delete(Author author)
        {
            try
            {
                _Context.Authors.Remove(author);
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
                _Context.Remove(_Context.Authors.Find(authorId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Author FirstOrDefault(Expression<Func<Author, bool>> filter)
        {
            IQueryable<Author> query = _Context.Authors.Where(filter);

            return query.FirstOrDefault();
        }

        public Author Get(int authorId)
        {
            return _Context.Authors.Find(authorId);
        }

        public IEnumerable<Author> GetAll()
        {
            return _Context.Authors;
        }

        public IEnumerable<string> GetAllNames()
        {
            return _Context.Authors.Select(x => x.Name);
        }

        public bool Insert(Author author)
        {
            try
            {
                _Context.Authors.Add(author);
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

        public bool Update(Author author)
        {
            try
            {
                _Context.Authors.Update(author);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
