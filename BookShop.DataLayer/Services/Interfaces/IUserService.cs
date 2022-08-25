using BookShop.DataLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public interface IUserService
    {
        bool Insert(User user);

        bool Update(User user);

        bool Delete(User user);

        bool Delete(int userId);

        User Get(int userId);

        IEnumerable<User> GetByUserPass(string username,string password);

        IEnumerable<User> GetAll();

        User FirstOrDefault(Expression<Func<User, bool>> filter);

        void Save();

        //public User Get(int id);

        //public IEnumerable<User> GetAll();

        //public RefreshToken GetUserRefreshToken(string username, string refreshToken);

        //public bool InsertUserRefreshToken(RefreshToken userrefreshToken);

        //public bool DeleteUserRefreshToken(RefreshToken userrefreshToken);

        //public bool UpdateUserRefreshToken(RefreshToken userRefreshtoken);

        //public Task<bool> IsValidUser(User user);
    }
}
