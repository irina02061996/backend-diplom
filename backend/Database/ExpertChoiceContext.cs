using backend.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class ExpertChoiceContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IntervalSolution> IntervalSolutions { get; set; }

        public DbSet<Chart> Charts { get; set; }

        public DbSet<DataChart> DataCharts { get; set; }
        public DbSet<Value> Values { get; set; }

        public DbSet<ModifierType> ModifierTypes { get; set; }
        public DbSet<DemandType> DemandTypes { get; set; }

        public ExpertChoiceContext(DbContextOptions<ExpertChoiceContext> options)
    : base(options)
    { }
    }
}
