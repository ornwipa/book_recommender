using Microsoft.EntityFrameworkCore;
using recommender.Models;

namespace recommender.Data
{
    public class BookRecommendedContext : DbContext
    {
        public BookRecommendedContext (DbContextOptions<BookRecommendedContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}