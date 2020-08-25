using System;

namespace recommender.Models
{
    public class Rating
    {
        public int book_id { get; set; }
        public int user_id { get; set; }
        public int rating_ { get; set; }
    }
}