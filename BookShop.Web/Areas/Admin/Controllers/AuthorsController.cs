using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookShop.DataLayer;
using BookShop.DataLayer.Models;
using BookShop.DataLayer.Services;

namespace BookShop.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AuthorsController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public AuthorsController(IBookService bookService , IAuthorService authorService)
        {
            _bookService = bookService;
            _authorService = authorService;
        }

        // GET: Admin/Authors
        public async Task<IActionResult> Index()
        {
              return _authorService.GetAll() != null ? 
                          View(_authorService.GetAll().ToList()) :
                          Problem("Entity set 'BookShopContext.Authors'  is null.");
        }

        // GET: Admin/Authors/Details/5
        public async Task<IActionResult> Details(int? id)
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

            return View(author);
        }

        // GET: Admin/Authors/Create
        public IActionResult Create()
        {
            ViewBag.booksName = new SelectList(_bookService.GetAllNames());
            return View();
        }

        // POST: Admin/Authors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,About,Books")] Author author)
        {
            if (ModelState.IsValid)
            {
                //**Set FKs - Books before insert**
                //author.Books =

                _authorService.Insert(author);
                _authorService.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(author);
        }

        // GET: Admin/Authors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _authorService.GetAll() == null)
            {
                return NotFound();
            }
            ViewBag.booksName = new SelectList(_bookService.GetAllNames());
            var author =  _authorService.Get(id.Value);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        // POST: Admin/Authors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,About,Books")] Author author)
        {
            if (id != author.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //**Set FKs - Books before insert**
                    //author.Books =

                    _authorService.Update(author);
                    _authorService.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuthorExists(author.Id))
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
            return View(author);
        }

        // GET: Admin/Authors/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

            return View(author);
        }

        // POST: Admin/Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_authorService.GetAll() == null)
            {
                return Problem("Entity set 'BookShopContext.Authors'  is null.");
            }
            var author =_authorService.Get(id);
            if (author != null)
            {
                _authorService.Delete(author);
            }
            
            _authorService.Save();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id)
        {
          return (_authorService.GetAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
