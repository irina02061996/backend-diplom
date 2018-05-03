
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ChartsController : Controller
    {
        IService service;
        ExpertChoiceContext db;

        public ChartsController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new ChartService(db);
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel chart = service.Get(id);
  
            if (chart == null)
                return NotFound();

            return new ObjectResult(chart);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IModel chart = service.Delete(id);
            return Ok(chart);
        }
    }
}
