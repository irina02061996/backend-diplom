
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ChartsController : Controller
    {
        ExpertChoiceContext db;

        public ChartsController(ExpertChoiceContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<Chart> Get()
        {
            return db.Charts
                 .Include(c => c.IntervalSolution)
                 .ThenInclude(u => u.User)
                 .ToList();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Chart chart = db.Charts
                                .Include(c => c.IntervalSolution)
                                .ThenInclude(u => u.User)
                                .FirstOrDefault(x => x.Id == id);
            if (chart == null)
                return NotFound();

            return new ObjectResult(chart);
        }
    }
}
