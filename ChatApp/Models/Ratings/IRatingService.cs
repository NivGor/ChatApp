namespace ChatApp.Models.Ratings
{
    public interface IRatingService
    {
        public static List<Rating> ratings;

        public static double AverageRate = 0;

        public List<Rating> GetAll();

        public Rating Get(int id);

        public void Create(string name, int rate, string text);
        public void Edit(int id, int rate, string text);

        public void Delete(int id);
    }
}
