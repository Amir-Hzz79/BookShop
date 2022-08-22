using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace BookShop.Web.Areas.Admin.Pages.AuthorPages
{
    public class DeleteModel : PageModel
    {
        private readonly IAuthorService _authorService;

        public DeleteModel(IAuthorService context)
        {
            _authorService = context;
        }

        [BindProperty]
      public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _authorService.GetAll() == null)
            {
                return NotFound();
            }

            var author = _authorService.FirstOrDefault(m => m.Id == id);

            if (author == null)
            {
                return NotFound();
            }
            else 
            {
                Author = author;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsyinc(int? id)
        {
            if (id == null || _authorService.GetAll() == null)
            {
                return NotFound();
            }
            var author =  _authorService.Get(id.Value);

            if (author != null)
            {
                Author = author;
                _authorService.Delete(Author);
                _authorService.Save();
            }

            return RedirectToPage("./Index");
        }
    }
}
