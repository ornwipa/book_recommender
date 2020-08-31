using Microsoft.EntityFrameworkCore;
using recommender.Models;

namespace recommender.Data
{
    public class BookRatedContext : DbContext
    {
        public BookRatedContext (DbContextOptions<BookRatedContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}