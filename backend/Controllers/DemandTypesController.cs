using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;


namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class DemandTypesController : Controller
    {
        IService service;
        ExpertChoiceContext db;

        public DemandTypesController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new DemandTypeService(db);
        }

        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel demandType = service.Get(id);
            return new ObjectResult(demandType);
        }

        [HttpPost]
        public IActionResult Post(DemandType demandType)
        {
            service.Create(demandType);
            return Ok(demandType);
        }
    }
}
