using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database.Models
{
    public class Chart
    {
        [Key]
        [ForeignKey("IntervalSolution")]
        public int Id { get; set; }

        public string Type { get; set; }

        public IntervalSolution IntervalSolution { get; set; }

        [JsonIgnore]
        public virtual ICollection<DataChart> DataCharts { get; set; }
    }
}
