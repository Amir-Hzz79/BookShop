using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookShop.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IBookService _bookService;

        public IEnumerable<Book> books;

        public IEnumerable<Book> lastBooks;

        public IndexModel(ILogger<IndexModel> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        public void OnGet()
        {
            books = _bookService.GetAll();
            lastBooks = _bookService.GetLastBooks(3);
        }
    }
}