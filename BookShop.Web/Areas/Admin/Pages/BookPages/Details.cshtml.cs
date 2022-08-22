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
    public class DetailsModel : PageModel
    {
        private readonly IBookService _bookService;

        public DetailsModel(IBookService context)
        {
            _bookService = context;
        }

      public Book Book { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _bookService.GetAll() == null)
            {
                return NotFound();
            }

            var book = _bookService.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            else 
            {
                Book = book;
            }
            return Page();
        }
    }
}
