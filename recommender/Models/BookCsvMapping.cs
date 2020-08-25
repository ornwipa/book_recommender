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
            MapProperty(9, x => x.title);
            MapProperty(21, x => x.image_url);
        }
    }
}