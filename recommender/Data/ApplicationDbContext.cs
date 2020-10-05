using Microsoft.EntityFrameworkCore;
using recommender.Models;

namespace recommender.Data
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor for the context to use database
        /// </summary>
        /// <param name="options">DbContextOptionsBuilder().Options</param>
        /// <returns>DbContext; to use it, call a table: context.Books or context.Ratings</returns>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Store Book entities in a table called Books in database
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Store User entities in a table called Users in database
        /// </summary>
        public DbSet<Rating> Ratings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            builder.Entity<Book>(eb =>
            {
                eb.HasNoKey();
                eb.ToTable("Books");
            });
            builder.Entity<Rating>(eb =>
            {
                eb.HasNoKey();
                eb.ToTable("Ratings");
            });
        }
    }
}