using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class BooksController : Controller
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hosting;
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public BooksController(Microsoft.AspNetCore.Hosting.IHostingEnvironment hosting, IBookService context ,IAuthorService authorService)
        {
            _hosting = hosting;
            _bookService = context;
            _authorService = authorService;
        }

        // GET: Admin/Books
        public async Task<IActionResult> Index()
        {
              return _bookService.GetAll() != null ? 
                          View(_bookService.GetAll().ToList()) :
                          Problem("Entity set 'BookShopContext.Books'  is null.");
        }

        // GET: Admin/Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _bookService.GetAll() == null)
            {
                return NotFound();
            }

            var book =  _bookService.FirstOrDefault(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Admin/Books/Create
        public IActionResult Create()
        {
            ViewBag.authorsName = new SelectList(_authorService.GetAllNames());
            
            return View();
        }

        // POST: Admin/Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Authors,Image,AddDate,File,Price")] Book book, IFormFile Image,IFormFile File)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    book.Image = SaveMyFile(Image);
                }
                if (File != null)
                {
                    book.File = SaveMyFile(File);
                }

                //**Set FKs - Books before insert**
                //author.Authors =


                _bookService.Insert(book);
                _bookService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }
         
        // GET: Admin/Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _bookService.GetAll() == null)
            {
                return NotFound();
            }
            ViewBag.authorsName = new SelectList(_authorService.GetAllNames());
            var book = _bookService.Get(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Admin/Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Authors,Image,AddDate,File,Price")] Book book, IFormFile Image, IFormFile File)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (Image != null)
                    {
                        //Delete old image
                        DeleteMyFile(book.Image);

                        //Save new image 
                        book.Image = SaveMyFile(Image);
                    }
                    if (File != null)
                    {
                        //Delete old image
                        DeleteMyFile(book.File);

                        //Save new image 
                        book.File = SaveMyFile(File);
                    }

                    //**Set FKs - Authors before insert**
                    //book.Authors =


                    _bookService.Update(book);
                    _bookService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Admin/Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(book);
        }

        // POST: Admin/Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_bookService.GetAll() == null)
            {
                return Problem("Entity set 'BookShopContext.Books'  is null.");
            }
            var book = _bookService.Get(id);
            if (book != null)
            {
                //Delete book file
                DeleteMyFile(book.File);

                //Delete book image
                DeleteMyFile(book.Image);

                _bookService.Delete(book);
            }
            
            _bookService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_bookService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private string SaveMyFile(IFormFile file)
        {
            string path = _hosting.ContentRootPath + Guid.NewGuid() + Path.GetExtension(file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return path;
        }

        private void DeleteMyFile(string fileName)
        {
            string Path = _hosting.ContentRootPath + fileName;
            FileInfo file = new FileInfo(Path);
            if (file.Exists)
            {
                file.Delete();
            }
        }
    }
}
