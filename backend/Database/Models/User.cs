using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Database.Models
{
    public class User: IModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public virtual ICollection<IntervalSolution> IntervalSolutions { get; set; }
    }
}
