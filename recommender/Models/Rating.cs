using System;

namespace recommender.Models
{
    public class Rating
    {
        public int book_id { get; set; }
        public int user_id { get; set; }
        
        /// <summary>
        /// rating for each book_id by each user_id
        /// </summary>
        /// <value></value>
        public int rating_ { get; set; }
    }
}