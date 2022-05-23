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
    public class InvitationsController : ControllerBase
    {

        [HttpPost]
        public IActionResult Post([Bind("From,To,Server")] Invitation invitation)
        {
            User user = StaticDB.users.Find(x => x.Username == invitation.To);
            if (user == null)
            {
                return NotFound();
            }
            Contact contact = user.Contacts.Find(x => x.Id == invitation.From);
            if (contact != null)
            {
                return NotFound();
            }
            //setting a new contact
            contact = new Contact();
            contact.Id = invitation.From;
            contact.Name = invitation.From;
            contact.Server = invitation.Server;
            user.Contacts.Add(contact);
            return Ok();
        }
    }
}
