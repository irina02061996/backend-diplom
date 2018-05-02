using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace backend.Database.Models
{
    public class ModifierType: IModel
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        [JsonIgnore]
        public virtual ICollection<DataChart> DataCharts { get; set; }
    }
}
