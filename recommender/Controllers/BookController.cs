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
        private readonly BookRatedContext _contextRated;
        private readonly BookRecommendedContext _contextRecommended;
        public BookController(BookRatedContext contextRated, 
                                BookRecommendedContext contextRecommended)
        {
            _contextRated = contextRated;
            _contextRecommended = contextRecommended;
        }
        public async Task<IActionResult> RatedBookIndex()
        {
            return View(await _contextRated.Book.ToListAsync());
        }
        public async Task<IActionResult> RecommendedBookIndex()
        {
            return View(await _contextRecommended.Book.ToListAsync());
        }
    }
}