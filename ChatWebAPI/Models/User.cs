﻿using System.ComponentModel.DataAnnotations;

namespace ChatAppWebAPI.Models
{
    public class User
    {
        [Key]  
        public String Username { get; set; }
        [Required]
        public String DisplayName { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public List<Contact> Contacts { get; set; }
       


    }
}
