using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;

namespace BookShop.Web.Areas.Admin.Pages.AuthorPages
{
    public class CreateModel : PageModel
    {
        private readonly IAuthorService _authorService;

        public CreateModel(IAuthorService context)
        {
            _authorService = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Author Author { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
          if (!ModelState.IsValid || _authorService.GetAll() == null || Author == null)
            {
                return Page();
            }

            _authorService.Insert(Author);
            _authorService.Save();

            return RedirectToPage("./Index");
        }
    }
}
