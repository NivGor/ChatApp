using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChatWebAPI.Data;
using ChatWebAPI.Models;

namespace ChatWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvitationsController : ControllerBase
    {

        [HttpPost]
        public void Post([Bind("Id,From,To,Server")] Invitation invitation)
        {

        }
    }
}
