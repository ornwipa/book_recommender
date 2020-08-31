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
                    return this.id + " " + this.original_title + ", " + this.title;
            }
        }
    }    
}