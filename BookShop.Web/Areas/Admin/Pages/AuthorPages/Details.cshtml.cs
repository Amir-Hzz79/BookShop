using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookShop.DataLayer.Services;
using BookShop.DataLayer.Models;

namespace BookShop.Web.Areas.Admin.Pages.AuthorPages
{
    public class DetailsModel : PageModel
    {
        private readonly IAuthorService _authorService;

        public DetailsModel(IAuthorService context)
        {
            _authorService = context;
        }

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
    }
}
