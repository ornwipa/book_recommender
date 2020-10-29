using System;
using Microsoft.EntityFrameworkCore;
using recommender.Data;
using recommender.Services;

namespace recommender.Models
{
    public class NewUser : User
    {
        /// <summary>
        /// constructor for NewUser class
        /// </summary> 
        // public NewUser(IBookService bookService, IRatingService ratingService) : base(bookService, ratingService)
        public NewUser() : base()
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var context = new ApplicationDbContext(optionBuilder.Options);
            RatingService rating_service = new RatingService(context);
            this.user_id = Convert.ToString(rating_service.getLastUser() + 1);
        }
        
        /// <summary>
        /// Set ratings for guest, let all be zeros
        /// </summary>
        public override void setRatings()
        {
            this.rating = new int[10000]; // defaut values are zeros
        }
    }
}