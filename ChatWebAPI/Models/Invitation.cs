using System.ComponentModel.DataAnnotations;

namespace ChatWebAPI.Models
{
    public class Invitation
    {
        public int Id { get; set; }

        [Required]
        public string From { get; set; }

        [Required]
        public string To { get; set; }

        [Required]
        public string Server { get; set; }
    }
}
