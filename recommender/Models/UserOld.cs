using System;
using recommender.Services;

namespace recommender.Models
{
    public class OldUser : User
    {
        /// <summary>
        /// constructor for OldUser class
        /// </summary> 
        // public OldUser(IBookService bookService, IRatingService ratingService, string user_id) : base(bookService, ratingService, user_id)
        public OldUser(string user_id) : base()
        {
            this.user_id = user_id;
        }
        
        /// <summary>
        /// Set ratings for for existing users
        /// </summary>
        public override void setRatings()
        {
            int[][] user_jaggedarray = Rating.constructUserJaggedArray();
            this.rating = user_jaggedarray[Convert.ToInt32(this.user_id)];
        }
    }
}