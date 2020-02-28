using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TaskEntityFramework.Models;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.AspNetCore.JsonPatch;


namespace TaskEntityFramework.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ContactController : ControllerBase
    {
        private readonly ILogger<ContactController> _logger;
        private readonly ContactContext _context;

        public ContactController(ILogger<ContactController> logger, ContactContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            // var getit = new UserContacts
            // {
            //     Username = "darwin",
            //     Password = "utytnugYFDR79865",
            //     Email = "darwin@elmore.plus",
            //     Full_name = "Darwin Watterson"
            // };

            // _context.UserContacts.Add(getit);
            // _context.SaveChanges();
            var cont = _context.UserContacts;
            return Ok(cont);
           
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var tu = _context.UserContacts.First(e => e.Id == id);
            _context.SaveChanges();
            return Ok(tu);
            
        }
    
        [HttpPost]
        public IActionResult Post(UserContacts contacts)
        {
            _context.UserContacts.Add(contacts);
            _context.SaveChanges();
            return Ok(contacts);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var del = _context.UserContacts.First(e => e.Id == id);
            _context.UserContacts.Remove(del);
            _context.SaveChanges();
            return Ok("deleted");
        }

        [HttpPatch("{id}")]
        public IActionResult Patch([FromBody]JsonPatchDocument<UserContacts> contact, int id)
        {
            var r = _context.UserContacts.Find(id);
            contact.ApplyTo(r);
            _context.SaveChanges();
            return Ok(r);
        }
    }
}




