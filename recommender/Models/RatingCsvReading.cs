using System;
using System.Linq;
using System.Text;
using TinyCsvParser;
using System.Collections.Generic;

namespace recommender.Models
{
    public class TinyCsvParserRating
    {
        public static Rating[] ReadRatingCsv()
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CsvReaderOptions csvReaderOptions = new CsvReaderOptions(new[] { Environment.NewLine });
            CsvRatingMapping csvMapper = new CsvRatingMapping();
            CsvParser<Rating> csvParser = new CsvParser<Rating>(csvParserOptions, csvMapper);
            // var record = csvParser.ReadFromFile("../data_source/ratings.csv", Encoding.UTF8).ToList();
            var record = csvParser.ReadFromFile("Data/ratings.csv", Encoding.UTF8).ToList();
            return record.Select(x => x.Result).ToArray();
        }
    }
}