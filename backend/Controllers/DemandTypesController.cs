using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class DemandTypesController : Controller
    {
        ExpertChoiceContext db;

        public DemandTypesController(ExpertChoiceContext context)
        {
            this.db = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<DemandType> Get()
        {
            return db.DemandTypes.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DemandType demandType = db.DemandTypes.FirstOrDefault(x => x.Id == id);
            if (demandType == null)
                return NotFound();

            return new ObjectResult(demandType);
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post(DemandType demandType)
        {
            if (demandType == null)
            {
                return BadRequest();
            }

            db.DemandTypes.Add(demandType);
            db.SaveChanges();
            return Ok(demandType);
        }
    }
}
