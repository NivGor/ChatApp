namespace ChatApp.Models.Ratings
{
    public class RatingService : IRatingService
    {
        public static List<Rating> ratings = new List<Rating>();

        public static double AverageRate = 0;

        public List<Rating> GetAll() 
        {
            return ratings;
        }

        public Rating Get(int id)
        {
            return ratings.Find(x => x.Id == id);
        }

        public void Create(string name, int rate, string text)
        {
            int length = ratings.Count;
            int nextId = 0;
            if (ratings.Count > 0)
            {
                nextId = ratings.Max(x => x.Id) + 1;
            }
            ratings.Add(new Rating()
            {
                Id = nextId,
                Date = DateTime.Now,
                Name = name,
                Rate = rate,
                Text = text
            });

            if (AverageRate == 0)
            {
                AverageRate = rate;
            } else
            {
                AverageRate = (AverageRate * length + rate) / (length + 1);
            }

        }

        public void Edit(int id, int rate, string text)
        {
            Rating rating = Get(id);
            double rateSum = AverageRate * ratings.Count;
            rateSum = rateSum - rating.Rate + rate;
            rating.Rate = rate;
            rating.Text = text;
            AverageRate = rateSum / ratings.Count;
        }

        public void Delete(int id)
        {
            Rating rating = Get(id);
            if (ratings.Count > 1)
            {
                AverageRate = (AverageRate * ratings.Count - rating.Rate) / (ratings.Count - 1);
            } else
            {
                AverageRate = 0;
            }
            ratings.Remove(rating);
        }

    }
}
