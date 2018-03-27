
namespace backend.Database.Models
{
    public class CreateIntervalSolution
    {
        public string Formulation { get; set; }
        public float Result { get; set; }

        public string Type { get; set; }

        public int UserId { get; set; }
    }
}
