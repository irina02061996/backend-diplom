using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    class ChartService: IService
    {
        public ChartService(ExpertChoiceContext database): base(database)
        { }

        public override IModel Get(int id)
        {
            IModel chart = db.Charts
                    .Include(c => c.IntervalSolution)
                    .ThenInclude(u => u.User)
                    .FirstOrDefault(x => x.Id == id);

            return chart;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.Charts
                .Include(c => c.IntervalSolution)
                .ThenInclude(u => u.User)
                .ToList();
        }

        public override void Create(IModel model)
        {
            db.Charts.Add((Chart)model);
            db.SaveChanges();
        }

        public override IModel Delete(int id)
        {
            Chart chart = db.Charts.FirstOrDefault(x => x.Id == id);
            db.Charts.Remove(chart);
            db.SaveChanges();
            return chart;
        }
    }
}
