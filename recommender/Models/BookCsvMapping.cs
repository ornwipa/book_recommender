using System;
using TinyCsvParser.Mapping;

namespace recommender.Models
{
    public class CsvBookMapping : CsvMapping<Book>
    {
        public CsvBookMapping() : base()
        {
            MapProperty(0, x => x.id);
            MapProperty(1, x => x.book_id);
            MapProperty(5, x => x.isbn);
            MapProperty(7, x => x.authors);
            MapProperty(8, x => x.year);
            MapProperty(9, x => x.original_title);
            MapProperty(10, x => x.title);
            MapProperty(11, x => x.language_code);
            MapProperty(12, x => x.average_rating);
            MapProperty(13, x => x.ratings_count);
            MapProperty(21, x => x.image_url);
        }
    }
}