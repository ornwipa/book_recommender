using System;
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
            this.user_id = "55555"; // default
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