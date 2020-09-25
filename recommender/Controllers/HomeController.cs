using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using recommender.Models;
using recommender.Services;

namespace recommender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
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
            else if (Int32.Parse(user_id) >= 0 && Int32.Parse(user_id) < 52424) // temporary condition
            {
                // User user = new User(user_id);
                // return View(user)
                return View(_userService.getUser(user_id)); 
            }
            else
            {
                return Content("User ID does not exist.");
            }
        }

        [HttpGet]
        public IActionResult SetUser(string user_id)
        {
            if (ModelState.IsValid)
            {
                User current_user = new User(user_id);
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
                User current_user = new User(user_id);
                current_user.setRecommendedBook();
                return View(current_user);
            }
            return RedirectToAction("Index");
        }

        // GET: Home/Details/id
        public IActionResult Details(int id)
        {
            var model = Book.selectBook(id-1); // pass id 10000 to select row 9999
            return View("Details", model);
        }

        [HttpGet]
        public IActionResult Search(string search, string user_id)
        {
            User current_user = new User(user_id);
            current_user.search_matched = Book.searchBook(search);
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