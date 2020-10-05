using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using recommender.Data;
using recommender.Services;

namespace recommender.Models
{
    public class Book
    {
        [Required]
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
        
        [Display(Name = "Title")]
        public string title { get; set; }   
        
        [Display(Name = "Language")]
        public string language_code { get; set; }
        
        [Display(Name = "Average Rating")]
        public double average_rating { get; set; }
        
        [Display(Name = "Ratings Count")]
        public double ratings_count { get; set; }
        
        public string image_url { get; set; }
        
        /* can't use this constructor when data is read from csv
        public Book(int id)
        {
            this.id = id;
        } */ 
      
        /// <summary>
        /// Get a book record from the entire record Book[] array
        /// </summary>
        /// <param name="book_index">a row_id ranging from 0 to 9999</param>
        /// <returns>object of a Book class</returns>
        public static Book selectBook(int book_index, IBookService bookservice)
        {
            return bookservice.getBookData()[book_index];
            // var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // var context = new ApplicationDbContext(optionBuilder.Options);
            // return context.Books.Where(b => b.id == (book_index+1)).FirstOrDefault();
            // return TinyCsvParserBook.ReadBookCsv()[book_index];
        }

        /// <summary>
        /// Search for book(s) given authors, title, year and ISBN
        /// </summary>
        /// <param name="input">text to be matched with book information</param>
        /// <returns>a list of matched Book; if not found return an empty list</returns>
        public static List<Book> searchBook(string text_input, IBookService bookservice)
        {
            List<Book> matched = new List<Book>();
            Book[] book_data = bookservice.getBookData();
            // var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // var context = new ApplicationDbContext(optionBuilder.Options);
            // var book_data = context.Books.ToArray();
            // var book_data = TinyCsvParserBook.ReadBookCsv();
            for (int b = 0; b < book_data.Length; b++)
            {
                if (book_data[b] != null && text_input != null)
                {
                    if (book_data[b].ToString().ToLower().Contains(text_input.ToLower()))
                    {
                        matched.Add(book_data[b]);
                    }
                }
            }
            return matched;
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
            return display_title + ". (" + this.year + ") " + this.authors + ". " + this.isbn + ".";
        }
    // }
    
    // public class RatedBook : Book
    // {
        /// <summary>
        /// rating of the book by a specific user
        /// </summary>
        public int rating { get; set; }
        
        // public RatedBook(User user, int id) : base(id) // cannot use constructor

        /// <summary>
        /// From known rating (existing or new), set rating to this Book object
        /// </summary>
        /// <param name="user">object in User class with this.rating[]</param>
        public void setRating(User user)
        {
            this.rating = user.rating[this.id-1];
        }
        
        /// <summary>
        /// Set rating of this Book object, but records in User object is unchanged
        /// </summary>
        /// <param name="rating">rating as integer ranging from 0 to 5</param>
        public void setRating(int rating)
        {
            this.rating = rating; 
        }

        /// <summary>
        /// Set rating of this Book object
        /// </summary>
        /// <param name="user">the User who rates this Book</param>
        /// <param name="rating">new or changed rating from 0 to 5</param>
        public void setRating(User user, int rating)
        {
            user.rating[this.id-1] = rating;
            this.rating = rating;
        }
    }    
}