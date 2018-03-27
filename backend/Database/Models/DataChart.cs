using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Database.Models
{
    public class DataChart
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }
        public string Color { get; set; }

        public virtual Chart Chart { get; set; }
        public virtual DemandType DemandType { get; set; }
        public virtual ModifierType ModifierType { get; set; }

        [JsonIgnore]
        public virtual ICollection<Value> Values { get; set; }
    }
}
