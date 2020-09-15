using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using recommender.Models;

namespace recommender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            /*
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    SeedData.Initialize(services, "23", user_jaggedarray);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred seeding the database.");
                }
            }
            */
            host.Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// Test server's recommendation engine
        /// </summary>
        public static void testRecommendationAlgorithm()
        {
            // Test.testCsvParser();

            int[][] user_jaggedarray = Rating.constructUserJaggedArray();

            // Console.Write("Enter user_id: "); // will be replace with UI
            string user_id = "23"; // Console.ReadLine(); // will be replace with UI

            User current_user = User.accessUser(user_jaggedarray, Convert.ToInt32(user_id));

            List<Book> rated_book = current_user.getRatedBook();

            List<Book> recommended_book = current_user.getRecommendedBook();  
        }

        /// <summary>
        /// Test search function
        /// </summary>
        public static void testSearch()
        {
            List<Book> search = Book.searchBook("J.K. Rowling");
            if (search.Count == 0)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                for (int b = 0; b < search.Count; b++)
                {
                    Console.WriteLine(search[b].ToString());
                }
            }
        }
    }
}