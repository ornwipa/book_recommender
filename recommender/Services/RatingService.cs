using System;
using recommender.Data;
using recommender.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace  recommender.Services
{
    public class RatingService : IRatingService
    {       
        public Rating[] getRatingData()
        {
           return TinyCsvParserRating.ReadRatingCsv();
        }

        private readonly ApplicationDbContext _context;
        public RatingService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Rate(int rating_, int book_id, string user_id)
        {
            Rating row = _context.Ratings.
                        Where(r => r.book_id == book_id && r.user_id == (Convert.ToInt32(user_id)+1)).FirstOrDefault();
            
            // if (row == null) throw new Exception("Rating record is not found. Add new rating instead.");
            if (row == null)
            {
                row = new Rating();
                row.book_id = book_id;
                row.user_id = (Convert.ToInt32(user_id)+1);
                _context.Add(row); // add new row for new rating
            }

            row.rating_ = rating_;
            if (row.rating_ == 0)
            {
                _context.Remove(row); // do not retain data when rating = 0
            }
            
            var saveResult = _context.SaveChanges();
            return saveResult == 1;
        }

        public int getLastUser()
        {
            IEnumerable<int> new_users = _context.Ratings.Where(r => r.user_id >= 53423).ToArray().Select(x => x.user_id);
            int last_user = new_users.Max();
            return last_user;
        }
    }
}