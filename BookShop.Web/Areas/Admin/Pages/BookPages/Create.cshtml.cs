using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookShop.DataLayer;
using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;

namespace BookShop.Web.Areas.Admin.Pages.BookPages
{
    public class CreateModel : PageModel
    {
        private readonly IBookService _bookService;

        public CreateModel(IBookService context)
        {
            _bookService = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; } = default!;


        
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid || _bookService.GetAll() == null || Book == null)
            {
                return Page();
            }

            _bookService.Insert(Book);
            _bookService.Save();

            return RedirectToPage("./Index");
        }
    }
}
