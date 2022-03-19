namespace DogGo.Models.ViewModels
{
    public class WalkerViewModel
    {
        public Walker Walker { get; set; }
        public List<Walks> Walks { get; set; }
        public List<Dog> Dogs { get; set; }
        public Owner Owner { get; set; }
    }
}
