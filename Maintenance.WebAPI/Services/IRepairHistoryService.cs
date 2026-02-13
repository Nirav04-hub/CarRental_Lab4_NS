using Maintenance.WebAPI.Models;

namespace Maintenance.WebAPI.Services
{
    public interface IRepairHistoryService
    {
        List<RepairHistory> GetVehicleById(int vehicleId);
    }
}
