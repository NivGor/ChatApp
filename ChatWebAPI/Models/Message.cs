using System.ComponentModel.DataAnnotations;

namespace ChatAppWebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Sender { get; set; }
        [Required]
        public string Reciever { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public string Time { get; set; }
    }
}
