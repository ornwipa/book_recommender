using Microsoft.EntityFrameworkCore;
using recommender.Models;

namespace recommender.Data
{
    public class BookContext : DbContext
    {
        public BookContext (DbContextOptions<BookContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}