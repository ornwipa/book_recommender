using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using recommender.Models;

namespace recommender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // CreateHostBuilder(args).Build().Run();
            testBookModel();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        public static void testBookModel()
        {
            var records = TinyCsvParserRead.ReadBookCsv();
            int n_books = records.Count;
            Console.WriteLine("Number of books " + n_books);
            Console.WriteLine("Type of records " + records[0]);
            Console.WriteLine("id " + records[0].id);
            Console.WriteLine("book_id " + records[0].book_id);
            Console.WriteLine("isbn " + records[0].isbn);
            Console.WriteLine("authors " + records[0].authors);
            Console.WriteLine("year " + records[0].year);
            Console.WriteLine("title " + records[0].title);
            Console.WriteLine("image_url " + records[0].image_url);
        }
    }
}
