using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public class FakeRepairHistoryService : IRepairHistoryService
    {
        public List<RepairHistory> GetVehicleById(int vehicleId)
        {
            return new List<RepairHistory>
        {
            new RepairHistory
            {
                Id = 1,
                VehicleId = vehicleId,
                RepairDate = DateTime.Now.AddDays(-10),
                DescriptionOfRepair = "Oil change",
                 RepairCost = 89.99m,
                RepairPerformedBy = "Quick Lube"
            },
            new RepairHistory
            {
                Id = 2,
                VehicleId = vehicleId,
                RepairDate = DateTime.Now.AddDays(-35),
                DescriptionOfRepair= "Brake pad replacement",
                RepairCost = 320.00m,
                RepairPerformedBy = "Brake Masters"
            }
        };
        }
    }
}
