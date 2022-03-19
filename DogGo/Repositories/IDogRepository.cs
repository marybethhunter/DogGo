using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        void AddDog(Dog dog);
        void UpdateDog(Dog dog);
        Dog GetDogById(int id);
        void DeleteDog(int id);
        List<Dog> GetDogsByOwnerId(int ownerId);
    }
}
