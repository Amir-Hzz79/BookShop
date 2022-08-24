using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index(Book book)
        {
            return View(book);
        }
    }
}
