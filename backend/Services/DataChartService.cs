using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    class DataChartService: IService
    {
        public DataChartService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel dataChart = db.DataCharts
                .Include(c => c.Chart)
                .ThenInclude(i => i.IntervalSolution)
                .ThenInclude(u => u.User)
                .Include(d => d.DemandType)
                .Include(m => m.ModifierType)
                .FirstOrDefault(x => x.Id == id);

            return dataChart;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.DataCharts
                  .Include(c => c.Chart)
                  .ThenInclude(i => i.IntervalSolution)
                  .ThenInclude(u => u.User)
                  .Include(d => d.DemandType)
                  .Include(m => m.ModifierType)
                  .ToList();
        }

        public override void Create(IModel model)
        {
            db.DataCharts.Add((DataChart)model);
            db.SaveChanges();
        }

        public override IModel Delete(int id)
        {
            DataChart dataChart = db.DataCharts.FirstOrDefault(x => x.Id == id);
            db.DataCharts.Remove(dataChart);
            db.SaveChanges();
            return dataChart;
        }
    }
}
