using System;
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
    public class DataChartsController : Controller
    {
        ExpertChoiceContext db;

        public DataChartsController(ExpertChoiceContext context)
        {
            this.db = context;
        }


        [HttpGet]
        public IEnumerable<DataChart> Get()
        {
            return db.DataCharts
                  .Include(c => c.Chart)
                  .ThenInclude(i => i.IntervalSolution)
                  .ThenInclude(u => u.User)
                  .Include(d => d.DemandType)
                  .Include(m => m.ModifierType)
                  .ToList();
        }

  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DataChart dataChart = db.DataCharts
                .Include(c => c.Chart)
                .ThenInclude(i => i.IntervalSolution)
                .ThenInclude(u => u.User)
                .Include(d => d.DemandType)
                .Include(m => m.ModifierType)
                .FirstOrDefault(x => x.Id == id);

            if (dataChart == null)
                return NotFound();

            return new ObjectResult(dataChart);
        }


        [HttpPost]
        public IActionResult Post(CreateDataChart createDataChart)
        {
            if (createDataChart == null)
            {
                return BadRequest();
            }

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

            db.DataCharts.Add(dataChart);
            db.SaveChanges();

            return Ok(dataChart);
        }
    }
}
