using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatAppWebAPI.Models;
using ChatWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace ChatWebAPI.Controllers
{
    [ApiController]
    
    public class ContactsController : ControllerBase
    {

        // GET: Contacts
        [HttpGet]
        [Route("/api/{username}/[controller]")]
        public IEnumerable<Contact> Get(string username)
        {
            return StaticDB.users.Find(x => x.Username == username).Contacts;
        }






        //// POST: Contacts/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/api/{username}/[controller]")]
        public void Post(string username, [Bind("Id,Name,Server,Last,LastDate")] Contact contact)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            user.Contacts.Add(contact);
        }

        [HttpGet]
        [Route("/api/{username}/[controller]/{contactId}")]
        public Contact Details(string username, string contactId)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            var contact = user.Contacts.Find(x => x.Id == contactId);
            return contact;
        }

        [HttpPut]
        [Route("/api/{username}/[controller]/{contactId}")]
        public void Put(string username, string contactId, string name, string server)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            contact.Name = name;
            contact.Server = server;
        }



        // GET: Contacts/Delete/5
        [HttpDelete]
        [Route("/api/{username}/[controller]/{contactId}")]
        public void Delete(string username,string contactId)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            Contact contact = user.Contacts.Find(x => x.Id == contactId);
            if (contact != null)
            {
                user.Contacts.Remove(contact);
            }
        }


    }
}

