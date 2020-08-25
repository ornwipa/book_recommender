using System;

namespace recommender.Models
{
    public class Book
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public int isbn { get; set; }
        public string authors { get; set; }
        public double year { get; set; } // original_publication_year;
        public string title { get; set; } // original_title;
        public string image_url { get; set; }
    }    
}