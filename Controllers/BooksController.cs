using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RSWEB_SProekt.Data;
using RSWEB_SProekt.Models;
using RSWEB_SProekt.ViewModels;

namespace RSWEB_SProekt.Controllers
{
    public class BooksController : Controller
    {
        private readonly RSWEB_SProektContext _context;

        public BooksController(RSWEB_SProektContext context)
        {
            _context = context;
        }

        // GET: Books
        public async Task<IActionResult> Index(string TitleString, string GenreString, string Sort)
        {
            IQueryable<Book> books = _context.Book.AsQueryable();
            IQueryable<string> GenreQuery = _context.Book.OrderBy(m => m.Genre).Select(m => m.Genre).Distinct();
            List<string> sortTypesList = new List<string>(2);
            sortTypesList.Add("Растечки");
            sortTypesList.Add("Опаднувачки");


            if (!string.IsNullOrEmpty(TitleString))
            {
                books = books.Where(s => s.Title.Contains(TitleString));
            }

            if (!string.IsNullOrEmpty(GenreString))
            {
                books = books.Where(s => s.Genre.Contains(GenreString));
            }
            if (!string.IsNullOrEmpty(Sort))
            {
                if (string.Compare(Sort, "Растечки") == 0)
                {
                    books = books.OrderBy(x => x.Price);
                }
                else
                {
                    books = books.OrderByDescending(x => x.Price);
                }
            }


            var bookFilter = new BookFilter
            {
                GenreList = new SelectList(await GenreQuery.ToListAsync()),
                Books = await books.Include(s=>s.Author).ToListAsync(),
                SortTypes= new SelectList(sortTypesList)
            };

            return View(bookFilter);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FirstName");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,PublishingHouse,Price,NumberOfPages,AuthorId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,PublishingHouse,Price,NumberOfPages,AuthorId")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
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
            ViewData["AuthorId"] = new SelectList(_context.Author, "Id", "FirstName", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'RSWEB_SProektContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return (_context.Book?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> BooksByAuthor(int? Id, string TitleString, string GenreString)
        {

            if (Id == null)
            {
                return NotFound();
            }
            
            IQueryable<Book> books = _context.Book.Where(s=>s.AuthorId==Id);
            IQueryable<string> GenreQuery = _context.Book.OrderBy(m => m.Genre).Select(m => m.Genre).Distinct();

            if (!string.IsNullOrEmpty(TitleString))
            {
                books = books.Where(s => s.Title.Contains(TitleString));
            }

            if (!string.IsNullOrEmpty(GenreString))
            {
                books = books.Where(s => s.Genre.Contains(GenreString));
            }

            var bookFilter = new BookFilter
            {
                GenreList = new SelectList(await GenreQuery.ToListAsync()),
                Books = await books.Include(s => s.Author).ToListAsync()
            };

            return View(bookFilter);
        }
    }
}
