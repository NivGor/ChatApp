using System.ComponentModel.DataAnnotations;

namespace ChatAppWebAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime Created { get; set; }
        [Required]
        public Boolean Sent { get; set; }
        
    }
}
