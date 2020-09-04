using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using recommender.Models;

namespace recommender.Controllers
{
    public class BookController : Controller
    {
        private readonly Book _book;
        public BookController(int id)
        {
            _book = Book.selectBook(id);
        }
        public ActionResult Details(int id)
        {
            // BookController book_control = new BookController(id);
            // var model = book_control._book;
            var model = Book.selectBook(id);
            return View("Details", model);
        }
    }
}