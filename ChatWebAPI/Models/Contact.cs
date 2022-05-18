using System.ComponentModel.DataAnnotations;

namespace ChatAppWebAPI.Models
{
    public class Contact
    {
        public String Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Server { get; set; }
        [Required]
        public String Last { get; set; }
        [Required]
        public DateTime LastDate { get; set; }

    }
}
