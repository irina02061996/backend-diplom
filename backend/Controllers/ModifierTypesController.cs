
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ModifierTypesController : Controller
    {
        IService service;
        ExpertChoiceContext db;

        public ModifierTypesController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new ModifierTypeService(db);
        }


        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel modifierType = service.Get(id);
            return new ObjectResult(modifierType);
        }

  
        [HttpPost]
        public IActionResult Post(ModifierType modifierType)
        {
            service.Create(modifierType);
            return Ok(modifierType);
        }
    }
}
