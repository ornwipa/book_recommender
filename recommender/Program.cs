using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using recommender.Data;
using recommender.Models;

namespace recommender
{
    public class Program
    {
        public static void Main(string[] args)
        {                 
            double[][] user_jaggedarray = User.constructUserJaggedArray();
            var host = CreateHostBuilder(args).Build();
            
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

            host.Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// This is the server's recommendation engine, which has been tested.
        /// </summary>
        public static void recommendationAlgorithm()
        {
            // Test.testCsvParser();

            double[][] user_jaggedarray = User.constructUserJaggedArray();

            // Console.Write("Enter user_id: "); // will be replace with UI
            string user_id = "23"; // Console.ReadLine(); // will be replace with UI

            User current_user = User.accessUser(user_jaggedarray, Convert.ToInt32(user_id));

            List<Book> rated_book = current_user.getRatedBook();

            List<User> similar_user = current_user.similarUser(user_jaggedarray);

            List<Book> recommended_book = current_user.getRecommendedBook(similar_user);  
        }
    }
}