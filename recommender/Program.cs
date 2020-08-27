using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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
            
            // Test.testCsvParser();

            int[][] user_matrix = User.constructUserMatrix();

            Console.Write("Enter user_id: "); // will be replace with UI
            string user_row = Console.ReadLine(); // will be replace with UI
            int user_index = Convert.ToInt32(user_row);

            User current_user = User.accessUser(user_matrix, user_index);
            Console.WriteLine("{0}", current_user.rating[2319]); // test the non-zero one
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
