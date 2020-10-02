using System;

namespace recommender.Models
{
    public class OldUser : User
    {
        /// <summary>
        /// constructor for OldUser class
        /// </summary> 
        public OldUser(string user_id) : base(user_id)
        {
            this.user_id = user_id;
            this.setRatings(); // different for User and Guest objects
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