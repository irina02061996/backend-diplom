using System.ComponentModel.DataAnnotations;

namespace backend.Database.Models
{
    public class IntervalSolution
    {
        [Key]
        public int Id { get; set; }

        public string Formulation { get; set; }
        public float Result { get; set; }

        public virtual User User { get; set; }
    }
}
