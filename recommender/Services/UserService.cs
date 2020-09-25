using System;
using recommender.Data;
using recommender.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace  recommender.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        public User getUser(string user_id)
        {
            User current_user;
            try
            {
                current_user = _context.Users.Where(x => x.user_id == user_id).Single();
            }
            catch (System.ArgumentNullException e)
            {
                current_user = new User(user_id);  
                Console.WriteLine("Throw {0} and get user from csv file instead", e);          
            }
            return current_user;
        }
    }
}