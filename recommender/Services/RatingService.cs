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
           // return _context.Ratings.ToArray();
           return TinyCsvParserRating.ReadRatingCsv();
        }
    }
}