using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.DataLayer;
using BookShop.DataLayer.Models;

namespace BookShop.Web.Areas.Admin.Pages.AuthorPages
{
    public class IndexModel : PageModel
    {
        private readonly BookShop.DataLayer.BookShopContext _context;

        public IndexModel(BookShop.DataLayer.BookShopContext context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Authors != null)
            {
                Author = await _context.Authors.ToListAsync();
            }
        }
    }
}
