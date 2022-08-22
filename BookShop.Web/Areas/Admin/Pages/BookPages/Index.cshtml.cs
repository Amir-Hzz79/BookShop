using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.DataLayer;
using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;

namespace BookShop.Web.Areas.Admin.Pages.BookPages
{
    public class IndexModel : PageModel
    {
        private readonly IBookService _bookService;

        public IndexModel(IBookService context)
        {
            _bookService = context;
        }

        public IList<Book> Books { get;set; } = default!;

        //public List<> AuthorsName { get;set; };

        public async Task OnGetAsync()
        {
            if (_bookService.GetAll() != null)
            {
                Books = _bookService.GetAll().ToList();
                //AuthorsName = Books.Authors.Name;
            }
        }
    }
}
