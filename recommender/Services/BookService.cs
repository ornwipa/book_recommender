using System;
using recommender.Data;
using recommender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace  recommender.Services
{
    public class BookService : IBookService
    {
        public Book[] getBookData()
        {
            // return _context.Books.ToArray();
            return TinyCsvParserBook.ReadBookCsv();
        }
    }
}