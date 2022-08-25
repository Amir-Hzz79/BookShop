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
    public class UserService : IUserService
    {
        private readonly BookShopContext _context;
        //private readonly UserManager<User> _userManager;

        public UserService(BookShopContext context/*,UserManager<User> userManager*/)
        {
            _context = context;
            //_userManager = userManager;
        }

        public bool Delete(User user)
        {
            try
            {
                _context.Users.Remove(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int userId)
        {
            try
            {
                _context.Users.Remove(_context.Users.Find(userId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User FirstOrDefault(Expression<Func<User, bool>> filter)
        {
            IQueryable<User> query = _context.Users.Where(filter);

            return query.FirstOrDefault();
        }

        public User Get(int userId)
        {
            return _context.Users.Find(userId);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public bool Insert(User user)
        {
            try
            {
                _context.Users.Add(user);
                return true;
            }
            catch
            {

                return false;
            }
        }

        //public User Get(int id)
        //{
        //    return _context.Users.Find(id);
        //}

        //public IEnumerable<User> GetAll()
        //{
        //    return _context.Users;
        //}



        //public RefreshToken GetUserRefreshToken(string userId, string refreshToken)
        //{
        //    return _context.UserRefreshTokens.FirstOrDefault(x => x.UserId == userId && x.RefreshTokenString == refreshToken && x.IsActive == true);
        //}

        //public bool InsertUserRefreshToken(RefreshToken userrefreshToken)
        //{
        //    try
        //    {
        //        _context.UserRefreshTokens.Add(userrefreshToken);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool DeleteUserRefreshToken(RefreshToken userrefreshToken)
        //{
        //    try
        //    {
        //        _context.UserRefreshTokens.Remove(userrefreshToken);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public bool UpdateUserRefreshToken(RefreshToken userRefreshtoken)
        //{
        //    try
        //    {
        //        _context.UserRefreshTokens.Update(userRefreshtoken);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

        //public Task<bool> IsValidUser(User user)
        //{
        //    var result = _userManager.CheckPasswordAsync(user, user.Password);
        //    return result;
        //}

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(User user)
        {
            try
            {
                _context.Users.Update(user);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<User> Get(User user)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> IUserService.GetByUserPass(string username, string password)
        {
            return _context.Users.Where(u => u.Username == username && u.Password == password);
        }
    }
}
