using BookShop.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.DataLayer.Services
{
    public interface IRoleService
    {
        bool Insert(Role role);

        bool Update(Role role);

        bool Delete(Role role);

        bool Delete(int roleId);

        Role Get(int roleId);

        IEnumerable<Role> GetAll();

        Role FirstOrDefault(Expression<Func<Role, bool>> filter);

        void Save();
    }
}
