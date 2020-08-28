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
            // Test.testCsvParser();

            double[][] user_jaggedarray = User.constructUserJaggedArray();

            // Console.Write("Enter user_id: "); // will be replace with UI
            string user_row = "23"; // Console.ReadLine(); // will be replace with UI
            int user_index = Convert.ToInt32(user_row);

            User current_user = User.accessUser(user_jaggedarray, user_index);

            List<Book> rated_book = current_user.getRatedBook();

            List<User> similar_user = current_user.similarUser(user_jaggedarray);

            List<Book> recommended_book = current_user.getRecommendedBook(similar_user);       

            CreateHostBuilder(args).Build().Run();            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}