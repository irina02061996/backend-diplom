
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ModifierTypesController : Controller
    {
        ExpertChoiceContext db;

        public ModifierTypesController(ExpertChoiceContext context)
        {
            this.db = context;
        }


        [HttpGet]
        public IEnumerable<ModifierType> Get()
        {
            return db.ModifierTypes.ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            ModifierType modifierType = db.ModifierTypes.FirstOrDefault(x => x.Id == id);

            return new ObjectResult(modifierType);
        }

  
        [HttpPost]
        public IActionResult Post(ModifierType modifierType)
        {
            db.ModifierTypes.Add(modifierType);
            db.SaveChanges();
            return Ok(modifierType);
        }
    }
}
