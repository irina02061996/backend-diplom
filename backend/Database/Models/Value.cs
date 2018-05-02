using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database.Models
{
    public class Value: IModel
    {
        [Key]
        public int Id { get; set; }

        public float X { get; set; }
        public float Y { get; set; }

        public virtual DataChart DataChart { get; set; }
    }
}
