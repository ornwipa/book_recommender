using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using recommender.Data;
using recommender.Models;

namespace recommender.Controllers
{
    public class BookController : Controller
    {
        /*
        private readonly BookContext _context;
        public BookController(BookContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> RatedBookIndex()
        {
            return View(await _context.Book.ToListAsync());
        }
        public async Task<IActionResult> RecommendedBookIndex()
        {
            return View(await _context.Book.ToListAsync());
        }
        */
        private readonly User _current_user;
        public BookController(User user)
        {
            _current_user = user;
        }
        public IActionResult RatedBookIndex()
        {
            List<Book> rated_book = _current_user.getRatedBook();
            var model = rated_book;
            return View(model);
        }    
        public IActionResult RecommendedBookIndex()
        {
            List<User> similar_user = _current_user.similarUser();
            List<Book> recommended_book = _current_user.getRecommendedBook(similar_user);
            var model = recommended_book;
            return View(model);
        }
    }
}