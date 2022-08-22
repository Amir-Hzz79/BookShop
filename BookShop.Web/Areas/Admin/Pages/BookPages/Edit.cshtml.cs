using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.Areas.Admin.Pages.BookPages
{
    public class EditModel : PageModel
    {
        private readonly IBookService _bookService;

        public EditModel(IBookService context)
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
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _bookService.Update(Book);

            try
            {
                _bookService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return (_bookService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
