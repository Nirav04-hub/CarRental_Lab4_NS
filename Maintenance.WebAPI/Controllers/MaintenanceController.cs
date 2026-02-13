using Maintenance.WebAPI.Models;
using Maintenance.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Maintenance.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IRepairHistoryService _repairHistoryService;

        public MaintenanceController(IRepairHistoryService repairHistoryService)
        {
            _repairHistoryService = repairHistoryService;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public ActionResult<List<RepairHistory>> GetRepairs(int vehicleId)
        {
            var result = _repairHistoryService.GetVehicleById(vehicleId);
            return Ok(result);
        }
    }
}
