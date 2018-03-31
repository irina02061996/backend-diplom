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

        [HttpGet]
        public IEnumerable<DemandType> Get()
        {
            return db.DemandTypes.ToList();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DemandType demandType = db.DemandTypes.FirstOrDefault(x => x.Id == id);

            return new ObjectResult(demandType);
        }

        [HttpPost]
        public IActionResult Post(DemandType demandType)
        {
            db.DemandTypes.Add(demandType);
            db.SaveChanges();
            return Ok(demandType);
        }
    }
}
