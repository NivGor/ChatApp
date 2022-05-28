using System.ComponentModel.DataAnnotations;

namespace ChatApp.Models.Ratings
{
    public class Rating
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1,5)]
        public int Rate { get; set; }
        public string Text { get; set; }
        
        public DateTime Date { get; set; }
    }
}
