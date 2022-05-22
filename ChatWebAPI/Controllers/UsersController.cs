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
    public class UsersController : ControllerBase
    {

        [HttpGet]
        [Route("/api/[controller]")]
        public IEnumerable<User> Get(){
            return StaticDB.users;
            }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("/api/[controller]")]
        public void Add([Bind("Username,DisplayName,Password")] User user)
        {
            StaticDB.users.Add(user);
        }

      
    }
}
