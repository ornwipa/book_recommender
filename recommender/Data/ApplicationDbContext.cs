using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using recommender.Services;

namespace recommender.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Store BookService entities in a table called Books in database
        /// </summary>
        public DbSet<BookService> Books { get; set; }

        /// <summary>
        /// Store UserService entities in a table called Users in database
        /// </summary>
        public DbSet<RatingService> Ratings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // base.OnModelCreating(builder);
            builder.Entity<BookService>(eb =>
            {
                eb.HasNoKey();
                eb.ToTable("Books");
            });
            builder.Entity<RatingService>(eb =>
            {
                eb.HasNoKey();
                eb.ToTable("Ratings");
            });
        }
    }
}