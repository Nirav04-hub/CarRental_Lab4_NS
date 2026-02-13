namespace Maintenance.WebAPI.Models
{
    public class RepairHistory
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime RepairDate { get; set; }
        public string DescriptionOfRepair { get; set; }
        public decimal RepairCost { get; set; }
        public string RepairPerformedBy { get; set; }

    }
}
