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
    }
}