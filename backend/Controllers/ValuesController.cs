
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.CreateModels;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        ExpertChoiceContext db;

        public ValuesController(ExpertChoiceContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Value> Get()
        {
            return db.Values
                .Include(v => v.DataChart)
                 .ThenInclude(c => c.Chart)
                .ThenInclude(i => i.IntervalSolution)
                .ThenInclude(u => u.User)
                .Include(v => v.DataChart)
                .ThenInclude(d => d.DemandType)
                .Include(v => v.DataChart)
                .ThenInclude(d => d.ModifierType)
                .ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Value value = db.Values
                .Include(v => v.DataChart)
                .ThenInclude(d => d.Chart)
                .ThenInclude(c => c.IntervalSolution)
                .ThenInclude(i => i.User)
                .FirstOrDefault(x => x.Id == id);

            if (value == null)
                return NotFound();

            return new ObjectResult(value);
        }


        [HttpPost]
        public IActionResult Post(CreateValue createValue)
        {
            if (createValue == null)
            {
                return BadRequest();
            }

            var dataChart = db.DataCharts.FirstOrDefault(data => data.Id == createValue.DataChartId);

            Value value = new Value()
            {
                X = createValue.X,
                Y = createValue.Y,
                DataChart = dataChart
            };

            db.Values.Add(value);
            db.SaveChanges();

            return Ok(value);
        }
    }
}
