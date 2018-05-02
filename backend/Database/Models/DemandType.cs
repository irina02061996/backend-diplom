using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Database.Models
{
    public class DemandType: IModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public virtual ICollection<DataChart> DataCharts { get; set; }
    }
}
