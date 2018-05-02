using backend.Database;
using backend.Database.Models;
using System.Collections.Generic;

namespace backend.Services
{
    abstract class IService
    {
        public ExpertChoiceContext db { get; set; }

        public IService(ExpertChoiceContext database)
        {
            db = database;
        }

        abstract public IModel Get(int id);
        abstract public IEnumerable<IModel> GetAll();
        abstract public void Create(IModel model);
    }
}
