using System.Threading.Tasks;
using recommender.Models;

namespace  recommender.Services
{
    public interface IBookService
    {
        Book[] getBookData();
    }
}