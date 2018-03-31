using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        ExpertChoiceContext db;

        public UsersController(ExpertChoiceContext context)
        {
            this.db = context;
        }


        [HttpGet]
        public IEnumerable<User> Get()
        {
            return db.Users.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = db.Users.FirstOrDefault(x => x.Id == id);
    
            return new ObjectResult(user);
        }


        [HttpGet]
        [Route("{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            User user = db.Users.FirstOrDefault(x => x.Email == email);

            return new ObjectResult(user);
        }


        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return Ok(user);
        }
    }
}
