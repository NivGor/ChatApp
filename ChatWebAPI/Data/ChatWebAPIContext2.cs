using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChatAppWebAPI.Models;

namespace ChatWebAPI.Data
{
    public class ChatWebAPIContext2 : DbContext
    {
        public ChatWebAPIContext2 (DbContextOptions<ChatWebAPIContext2> options)
            : base(options)
        {
        }

        public DbSet<ChatAppWebAPI.Models.Contact>? Contact { get; set; }
    }
}
