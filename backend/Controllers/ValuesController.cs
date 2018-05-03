
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.CreateModels;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IService service;

        ExpertChoiceContext db;

        public ValuesController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new ValueService(db);
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }


        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel value = service.Get(id);
            return new ObjectResult(value);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CreateValue createValue)
        {
            if (createValue == null)
            {
                return Ok(null);
            }

            var dataChart = db.DataCharts.FirstOrDefault(data => data.Id == createValue.DataChartId);

            Value value = new Value()
            {
                X = createValue.X,
                Y = createValue.Y,
                DataChart = dataChart
            };

            service.Create(value);

            return Ok(value);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IModel value = service.Delete(id);
            return Ok(value);
        }
    }
}
