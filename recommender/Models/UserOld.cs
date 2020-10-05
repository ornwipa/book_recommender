using System;
using recommender.Services;

namespace recommender.Models
{
    public class OldUser : User
    {
        /// <summary>
        /// constructor for OldUser class
        /// </summary> 
        public OldUser(IBookService bookService, IRatingService ratingService, string user_id) : base(bookService, ratingService, user_id)
        {
            this.user_id = user_id;
            this.setRatings(); // different for User and Guest objects
        }
        
        /// <summary>
        /// Set ratings for for existing users
        /// </summary>
        public override void setRatings()
        {
            int[][] user_jaggedarray = Rating.constructUserJaggedArray(this._ratingService);
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }
    }
}