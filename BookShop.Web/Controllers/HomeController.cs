using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService _bookService;

        public HomeController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public IActionResult Index()
        {
            return View(_bookService.GetAll());
        }

        public IActionResult LastBooks()
        {
            return PartialView(_bookService.GetLastBooks(3));
        }

        public IActionResult BookList()
        {
            return PartialView(_bookService.GetAll());
        }
    }
}
