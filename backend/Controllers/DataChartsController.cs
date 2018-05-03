using System;
using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.CreateModels;
using backend.Database.Models;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace backend.Controllers

{
    [Route("api/[controller]")]
    public class DataChartsController : Controller
    {
        IService service;
        ExpertChoiceContext db;

        public DataChartsController(ExpertChoiceContext context)
        {
            this.db = context;
            this.service = new DataChartService(db);
        }


        [HttpGet]
        public IEnumerable<IModel> Get()
        {
            return service.GetAll();
        }

  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IModel dataChart = service.Get(id);

            return new ObjectResult(dataChart);
        }


        [HttpPost]
        public IActionResult Post([FromBody]CreateDataChart createDataChart)
        {
            var chart = db.Charts.FirstOrDefault(data => data.Id == createDataChart.ChartId);
            var demandType = db.DemandTypes.FirstOrDefault(data => data.Id == createDataChart.DemandTypeId);
            var modifierType = db.ModifierTypes.FirstOrDefault(data => data.Id == createDataChart.ModifierTypeId);

            DataChart dataChart = new DataChart()
            {
                Label = createDataChart.Label,
                Color = createDataChart.Color,

                Chart = chart,
                DemandType = demandType,
                ModifierType = modifierType
            };

            service.Create(dataChart);

            return Ok(dataChart);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            IModel dataChart = service.Delete(id);
            return Ok(dataChart);
        }
    }
}
