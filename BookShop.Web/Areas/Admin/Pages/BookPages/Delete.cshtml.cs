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
    public class DeleteModel : PageModel
    {
        private readonly IBookService _bookService;

        public DeleteModel(IBookService context)
        {
            _bookService = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _bookService.GetAll() == null)
            {
                return NotFound();
            }
            var book =  _bookService.Get(id.Value);

            if (book != null)
            {
                Book = book;
                _bookService.Delete(Book);
                _bookService.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
