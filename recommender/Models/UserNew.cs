using System;
using recommender.Services;

namespace recommender.Models
{
    public class NewUser : User
    {
        public NewUser() : base() {}

        /// <summary>
        /// constructor for NewUser class
        /// </summary> 
        public NewUser(IBookService bookService, IRatingService ratingService) : base(bookService, ratingService)
        {
            this.user_id = "55555"; // default
            this.rating = new int[10000]; // defaut values are zeros
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