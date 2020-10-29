using System.Threading.Tasks;
using recommender.Models;

namespace  recommender.Services
{
    public interface IRatingService
    {
        Rating[] getRatingData();
        bool Rate(int rating_, int book_id, string user_id);
        int getLastUser();
    }
}