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
    public class LoginController : ControllerBase
    {
        [HttpGet]
        [Route("/api/[controller]")]
        public User Get(string username, string password)
        {
            User user = StaticDB.users.Find(x => x.Username == username);
            if (user != null && user.Password == password)
            {
                return user;
            }
            return null;
        }
    }
}
