using System.Threading.Tasks;
using recommender.Models;

namespace  recommender.Services
{
    public interface IRatingService
    {
        Rating[] getRatingData();
    }
}