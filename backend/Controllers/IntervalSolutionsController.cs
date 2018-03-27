﻿using System.Collections.Generic;
using System.Linq;
using backend.Database;
using backend.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    public class IntervalSolutionsController : Controller
    {
        ExpertChoiceContext db;

        public IntervalSolutionsController(ExpertChoiceContext context)
        {
            this.db = context;
        }

        [HttpGet]
        public IEnumerable<IntervalSolution> Get()
        {
            return db.IntervalSolutions
                 .Include(m => m.User)
                 .ToList();
        }

  
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            IntervalSolution intervalSolution = db.IntervalSolutions
                .Include(m => m.User)
                .FirstOrDefault(x => x.Id == id);

            if (intervalSolution == null)
                return NotFound();

            return new ObjectResult(intervalSolution);
        }

  
        [HttpPost]
        public IActionResult Post(CreateIntervalSolution createIntervalSolution)
        {
            if (createIntervalSolution == null)
            {
                return BadRequest();
            }

            var user = db.Users.FirstOrDefault(data => data.Id == createIntervalSolution.UserId);

            IntervalSolution intervalSolution = new IntervalSolution()
                {
                    Formulation = createIntervalSolution.Formulation,
                    Result = createIntervalSolution.Result,
                    User = user
                };

            db.IntervalSolutions.Add(intervalSolution);
            db.SaveChanges();

            Chart chart = new Chart
            {
                Id = intervalSolution.Id,
                Type = createIntervalSolution.Type
            };

            db.Charts.Add(chart);
            db.SaveChanges();

            return Ok(intervalSolution);
        }
    }
}
