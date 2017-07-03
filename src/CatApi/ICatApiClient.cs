using System.Threading.Tasks;

namespace CatApi
{
    public interface ICatApiClient
    {
        Task<CatApiResponse> List(int max);
    }
}