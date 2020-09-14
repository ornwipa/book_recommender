using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using recommender.Models;

namespace recommender.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SetUser(User read_user)
        {
            if (ModelState.IsValid)
            {
                // return Content(read_user.user_id); // direct to the page showing user_id
                read_user.setRatings();
                UserController user_control = new UserController(read_user);
                return user_control.RatedBookIndex();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RecommendBook(User read_user)
        {
            if (ModelState.IsValid)
            {
                // return Content(read_user.user_id); // direct to the page showing user_id
                read_user.setRatings();
                UserController user_control = new UserController(read_user);
                return user_control.RecommendedBookIndex();
            }
            return RedirectToAction("Index");
        }

        // GET: Home/Details/id
        public ActionResult Details(int id)
        {
            var model = Book.selectBook(id-1); // pass id 10000 to select row 9999
            return View("Details", model);
        }

        [HttpGet]
        public ActionResult Search(string search)
        {
            List<Book> search_matched = Book.searchBook(search);
            if (search_matched == null)
            {
                return Content("Not Found");
            }
            else
            {
                ViewData.Model = search_matched;
                return View("SearchMatch");
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