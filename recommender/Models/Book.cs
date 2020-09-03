using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace recommender.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        
        public int book_id { get; set; }
        
        [Display(Name = "ISBN")]
        public int isbn { get; set; }
        
        [Display(Name = "Authors")]
        public string authors { get; set; }
        
        [Display(Name = "Year")]
        public double year { get; set; } // original_publication_year;
        
        [Display(Name = "Original Title")]
        public string original_title { get; set; }
        
        [Display(Name = "Other Title")]
        public string title { get; set; }   
        
        public string language_code { get; set; }
        
        public double average_rating { get; set; }
        
        public double ratings_count { get; set; }
        
        public string image_url { get; set; }
        
        /* can't use this constructor when data is read from csv
        public Book(int id)
        {
            this.id = id;
        } */ 
        
        public static Book selectBook(int book_index)
        {
            return TinyCsvParserBook.ReadBookCsv()[book_index];
        }
        
        public string citeBook(string style)
        {
            switch (style)
            {
                case "APA":
                // American Psychological Association
                    return this.authors + " (" + this.year + ") " + this.original_title + this.title + ".";
                case "MLA":
                // Modern Language Association
                    return this.authors + ". " + this.original_title + this.title + ". " + this.year + ".";
                default:
                    return this.id + " " + this.original_title + ", " + this.title + ", ISBN " + this.isbn;
            }
        }

        public override string ToString()
        {
            string display_title;
            if (this.original_title == "")
            {
                display_title = this.title;
            }
            else if (this.title == "" || this.title == this.original_title)
            {
                display_title = this.original_title;
            }
            else
            {
                display_title = this.original_title + ". " + this.title;
            }
            return display_title + ". (" + this.year + ") " + this.authors;
        }
    // }
    
    // public class RatedBook : Book
    // {
        /// <summary>
        /// rating of the book by a specific user
        /// </summary>
        public int rating { get; set; }
        
        // public RatedBook(User user, int id) : base(id) // not using base constructor
        // public RatedBook(User user)
        public void setRating(User user)
        {
            this.rating = user.rating[this.id];
        }
        public void setRating(int rating)
        {
            this.rating = rating;
        }
    }    
}