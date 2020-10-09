using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using recommender.Models;
using recommender.Data;
using recommender.Services;

namespace recommender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        public IRatingService _ratingService;

        public User current_user;

        public HomeController(ILogger<HomeController> logger, IBookService bookService, IRatingService ratingService)
        {
            _logger = logger;
            _bookService = bookService;
            _ratingService = ratingService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Welcome(string user_id)
        {          
            if (user_id == null)
            {
                return RedirectToAction("Index");
            }
            else 
            {
                if (Int32.TryParse(user_id, out int user_id_int))
                {
                    if (user_id_int >= 0 && user_id_int < 52424)
                    {
                        current_user = new OldUser(this._bookService, this._ratingService, user_id);
                        return View(current_user);
                    }
                    else
                    {
                        return Content("User ID does not exist. IDs are between 0 and 52423.");
                    }
                }
                else
                {
                    return Content("User ID can only be numers, not characters.");
                }
            }
        }

        public IActionResult AsGuest()
        {
            if (ModelState.IsValid)
            {
                current_user = new NewUser(this._bookService, this._ratingService);
                current_user.setRatedBook();
                return View("SetUser", current_user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult SetUser(string user_id)
        {
            if (ModelState.IsValid)
            {
                current_user = new User(this._bookService, this._ratingService, user_id);
                current_user.setRatedBook();
                return View(current_user);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RecommendBook(string user_id)
        {
            if (ModelState.IsValid)
            {
                current_user = new User(this._bookService, this._ratingService, user_id);
                if (current_user.rating.Sum() == 0) // in case of new users (redundancy to prevent ZeroDivisionError)
                {
                    return Content("You have not rated any books. Please rate some books so that our AI can recommend you books.");
                }
                current_user.setRecommendedBook();
                return View(current_user);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var model = Book.selectBook(id-1, this._bookService); // pass id 10000 to select row 9999
            return View("Details", model);
        }

        public IActionResult Rate(int rating_, int book_id, string user_id)
        {
            current_user = new User(this._bookService, this._ratingService, user_id); // to be replace by database entity
            current_user.setRating(book_id-1, rating_);
            // perform some logic here to save rating to database
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            using (ApplicationDbContext db = new ApplicationDbContext(optionBuilder.Options))
            {
                var row = db.Ratings.Where(r => r.book_id == book_id && r.user_id == Convert.ToInt32(user_id)).FirstOrDefault();
                if (row == null) throw new Exception("Rating record is not found. Something wrong with indexing");
                row.rating_ = rating_;
                db.SaveChanges();
            }
            current_user.setRatedBook(); 
            return View("SetUser", current_user);
        }

        [HttpGet]
        public IActionResult Search(string search, string user_id)
        {
            current_user = new User(this._bookService, this._ratingService, user_id);
            current_user.search_matched = Book.searchBook(search, this._bookService);
            if (current_user.search_matched == null)
            {
                return Content("Not Found");
            }
            else
            {
                return View("SearchMatch", current_user);
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}