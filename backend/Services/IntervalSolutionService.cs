using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    class IntervalSolutionService : IService
    {
        public IntervalSolutionService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel intervalSolution = db.IntervalSolutions
                .Include(m => m.User)
                .FirstOrDefault(x => x.Id == id);

            return intervalSolution;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.IntervalSolutions
                 .Include(m => m.User)
                 .ToList();
        }

        public override void Create(IModel model)
        {
            db.IntervalSolutions.Add((IntervalSolution)model);
            db.SaveChanges();
        }      
    }
}
