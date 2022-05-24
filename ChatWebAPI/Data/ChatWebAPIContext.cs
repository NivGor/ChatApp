using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatAppWebAPI.Models;
using ChatWebAPI.Models;

namespace ChatWebAPI.Data
{
    public class ChatWebAPIContext : DbContext
    {
        public ChatWebAPIContext (DbContextOptions<ChatWebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ChatAppWebAPI.Models.Contact>? Contact { get; set; }

        public DbSet<ChatAppWebAPI.Models.Message>? Message { get; set; }

        public DbSet<ChatWebAPI.Models.Invitation>? Invitation { get; set; }

        public DbSet<ChatAppWebAPI.Models.User>? User { get; set; }

        public DbSet<ChatWebAPI.Models.Transfer>? Transfer { get; set; }
    }
}
