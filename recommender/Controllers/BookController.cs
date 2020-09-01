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
    }
}