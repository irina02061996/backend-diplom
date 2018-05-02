using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    class ValueService: IService
    {
        public ValueService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel value = db.Values
                .Include(v => v.DataChart)
                .ThenInclude(d => d.Chart)
                .ThenInclude(c => c.IntervalSolution)
                .ThenInclude(i => i.User)
                .FirstOrDefault(x => x.Id == id);

            return value;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.Values
                .Include(v => v.DataChart)
                 .ThenInclude(c => c.Chart)
                .ThenInclude(i => i.IntervalSolution)
                .ThenInclude(u => u.User)
                .Include(v => v.DataChart)
                .ThenInclude(d => d.DemandType)
                .Include(v => v.DataChart)
                .ThenInclude(d => d.ModifierType)
                .ToList();
        }

        public override void Create(IModel model)
        {
            db.Values.Add((Value)model);
            db.SaveChanges();
        }
    }
}
