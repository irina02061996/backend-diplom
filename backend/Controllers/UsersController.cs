using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private IService service;
        private ExpertChoiceContext db;

        public UsersController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new UserService(db);
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel user = service.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Post([FromBody]IModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            service.Create(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IModel user = service.Delete(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }





        // [HttpGet]
        // public async Task<IEnumerable<User>> Get()
        // {
        //     IEnumerable<User> users = await db.Users.ToListAsync();
        //     return users;
        // }



        [HttpGet]
        [Route("GetUserByEmail/{email}")]
        public IActionResult GetUserByEmail(string email)
        {
            User user = db.Users.FirstOrDefault(x => x.Email == email);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

    }
}
