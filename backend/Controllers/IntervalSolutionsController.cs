using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class IntervalSolutionsController : Controller
    {
        IService service;
        ExpertChoiceContext db;

        public IntervalSolutionsController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new IntervalSolutionService(db);
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }

  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel intervalSolution = service.Get(id);
            return new ObjectResult(intervalSolution);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateIntervalSolution createIntervalSolution)
        {
            var user = db.Users.FirstOrDefault(data => data.Id == createIntervalSolution.UserId);

            IntervalSolution intervalSolution = new IntervalSolution()
            {
                Formulation = createIntervalSolution.Formulation,
                Result = createIntervalSolution.Result,
                User = user
            };

            service.Create(intervalSolution);

            Chart chart = new Chart
            {
                Id = intervalSolution.Id,
                Type = createIntervalSolution.Type
            };

            service = new ChartService(db);

            service.Create(chart);

            return Ok(intervalSolution);
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IModel intervalSolution = service.Delete(id);
            return Ok(intervalSolution);
        }
    }
}
