using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL;
using Pustok.Models;

namespace Pustok.Controllers
{
    public class BookController : Controller
    {
        private readonly PustokDbContext _context;

        public BookController(PustokDbContext context)
        {
            _context = context;
        }

        public IActionResult Detail(int id)
        {
            var book = _context.Books
            .Include(x => x.BookImages)
            .Include(x => x.Genre)
            .Include(x => x.BookTags)
            .Include(x => x.Author)
            .FirstOrDefault(x => x.Id == id);
            return View(book);
        }

        public IActionResult GetBookModal(int id)
        {
            var book = _context.Books
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .Include(x => x.BookImages)
                .Include(x=>x.BookTags)
                .FirstOrDefault(x => x.Id == id);

            return PartialView("_BookModalPartial", book);
        }
    }
}
