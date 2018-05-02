using backend.Database;
using backend.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    class DemandTypeService: IService
    {
        public DemandTypeService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel demandType = db.DemandTypes.FirstOrDefault(x => x.Id == id);

            return demandType;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.DemandTypes.ToList();
        }

        public override void Create(IModel model)
        {
            db.DemandTypes.Add((DemandType)model);
            db.SaveChanges();
        }
    }
}
