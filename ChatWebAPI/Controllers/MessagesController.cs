using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatAppWebAPI.Models;
using ChatWebAPI.Data;
using ChatWebAPI.Models;


namespace ChatWebAPI.Controllers
{
    [ApiController]
    public class MessagesController : ControllerBase
    {
        [HttpGet]
        [Route("{username}/Contacts/{contactId}/[controller]")]
        public IEnumerable<Message> Get(string username, string contactId)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            // maybe there is no need for this
            if (contact == null)
            {
                return new List<Message>();
            }
            return contact.messages;
        }


        [HttpPost]
        [Route("{username}/Contacts/{contactId}/[controller]")]
        public void Post(string username, string contactId, [Bind("Id,Content,Created,Sent")] Message message)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            contact.messages.Add(message);
        }

        [HttpGet]
        [Route("{username}/Contacts/{contactId}/[controller]/{id}")]
        public Message Details(string username, string contactId, int id)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            // maybe there is no need for this
            if (contact == null)
            {
                return null;
            }
            return contact.messages.Find(x => x.Id == id);
        }

        [HttpPut]
        [Route("{username}/Contacts/{contactId}/[controller]/{id}")]
        public void Put(string username, string contactId, int id, string content)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            Message message = contact.messages.Find(x => x.Id == id);
            message.Content = content;
        }

        [HttpDelete]
        [Route("{username}/Contacts/{contactId}/[controller]/{id}")]
        public void Delete(string username, string contactId, int id)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            Message message = contact.messages.Find(x => x.Id == id);
            contact.messages.Remove(message);
        }

    }
}
