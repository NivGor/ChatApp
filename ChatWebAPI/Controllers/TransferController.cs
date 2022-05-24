using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatWebAPI.Data;
using ChatWebAPI.Models;
using ChatAppWebAPI.Models;

namespace ChatWebAPI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class TransferController : ControllerBase
    {

        // POST: Transfer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public void Post([Bind("From,To,Content")] Transfer transfer)
        {
            User user = StaticDB.users.Find(x => x.Username == transfer.To);
            if (user != null)
            {
                Contact contact = user.Contacts.Find(x => x.Id == transfer.From);
                if (contact != null)
                {
                    string time = DateTime.Now.ToString();
                    int id = contact.messages.Count();
                    Message message = new Message()
                    {
                        Content = transfer.Content,
                        Created = time,
                        Id = id,
                        Sent = false
                    };
                    contact.messages.Add(message);
                }
            }
        }
    }
}
