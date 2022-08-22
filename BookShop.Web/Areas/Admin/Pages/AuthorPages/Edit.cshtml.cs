using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.DataLayer.Services;
using BookShop.DataLayer.Models;

namespace BookShop.Web.Areas.Admin.Pages.AuthorPages
{
    public class EditModel : PageModel
    {
        private readonly IAuthorService _authorService;

        public EditModel(IAuthorService context)
        {
            _authorService = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public IActionResult OnGetAsync(int? id)
        {
            if (id == null || _authorService.GetAll() == null)
            {
                return NotFound();
            }

            var author =  _authorService.FirstOrDefault(m => m.Id == id);
            if (author == null)
            {
                return NotFound();
            }
            Author = author;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _authorService.Update(Author);

            try
            {
                _authorService.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Author.Id))
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

        private bool AuthorExists(int id)
        {
          return (_authorService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
