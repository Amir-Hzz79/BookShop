using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public class RoleService : IRoleService
    {
        private readonly BookShopContext _context;

        public RoleService(BookShopContext context)
        {
            _context = context;
        }

        public bool Delete(Role role)
        {
            try
            {
                _context.Roles.Remove(role);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int roleId)
        {
            try
            {
                _context.Roles.Remove(_context.Roles.Find(roleId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Role FirstOrDefault(Expression<Func<Role, bool>> filter)
        {
            IQueryable<Role> query = _context.Roles.Where(filter);

            return query.FirstOrDefault();
        }

        public Role Get(int roleId)
        {
            return _context.Roles.Find(roleId);
        }

        public IEnumerable<Role> GetAll()
        {
            return _context.Roles;
        }

        public bool Insert(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                return true;
            }
            catch
            {

                return false;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public bool Update(Role role)
        {
            try
            {
                _context.Roles.Update(role);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
