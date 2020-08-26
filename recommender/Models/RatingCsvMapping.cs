using System;
using TinyCsvParser.Mapping;

namespace recommender.Models
{
    public class CsvRatingMapping : CsvMapping<Rating>
    {
        public CsvRatingMapping() : base()
        {
            MapProperty(0, x => x.book_id);
            MapProperty(1, x => x.user_id);
            MapProperty(2, x => x.rating_);
        }
    }
}