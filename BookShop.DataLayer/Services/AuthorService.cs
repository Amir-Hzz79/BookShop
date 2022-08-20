using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                _Context.authors.Remove(author);
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
                _Context.Remove(_Context.authors.Find(authorId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Author Get(int authorId)
        {
            return _Context.authors.Find(authorId);
        }

        public IEnumerable<Author> GetAll()
        {
            return _Context.authors;
        }

        public bool Insert(Author author)
        {
            try
            {
                _Context.authors.Add(author);
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
                _Context.authors.Update(author);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
