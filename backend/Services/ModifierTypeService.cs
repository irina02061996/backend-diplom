using backend.Database;
using backend.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace backend.Services
{
    class ModifierTypeService : IService
    {
        public ModifierTypeService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel modifierType = db.ModifierTypes.FirstOrDefault(x => x.Id == id);

            return modifierType;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.ModifierTypes.ToList();
        }

        public override void Create(IModel model)
        {
            db.ModifierTypes.Add((ModifierType)model);
            db.SaveChanges();
        }
    }
}
