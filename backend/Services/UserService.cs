using backend.Database;
using backend.Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Services
{
    class UserService: IService
    {
        public UserService(ExpertChoiceContext database) : base(database)
        { }

        public override IModel Get(int id)
        {
            IModel user = db.Users.FirstOrDefault(x => x.Id == id);
            return user;
        }

        public override IEnumerable<IModel> GetAll()
        {
            return db.Users.ToList();
        }

        public override void Create(IModel model)
        {
            db.Users.Add((User)model);
            db.SaveChanges();
        }
    }
}
