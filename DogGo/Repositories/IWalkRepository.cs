using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IWalkRepository
    {
        List<Walks> GetAllWalks();
        List<Walks> GetWalksByWalkerId(int walkerId);
    }
}
