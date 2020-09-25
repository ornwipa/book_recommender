using recommender.Models;

namespace  recommender.Services
{
    public interface IUserService
    {
        public User getUser(string user_id);
    }
}