
namespace backend.Database.CreateModels
{
    public class CreateDataChart
    {
        public string Label { get; set; }
        public string Color { get; set; }

        public int ChartId { get; set; }
        public int DemandTypeId { get; set; }
        public int ModifierTypeId { get; set; }
    }
}
