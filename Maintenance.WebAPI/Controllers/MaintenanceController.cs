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
        private readonly Dictionary<string, int> _usageCounts;


        public MaintenanceController(IRepairHistoryService repairHistoryService, Dictionary<string, int> usageCounts)
        {
            _repairHistoryService = repairHistoryService;
            _usageCounts = usageCounts;
        }

        [HttpGet("vehicles/{vehicleId}/repairs")]
        public ActionResult<List<RepairHistory>> GetRepairs(int vehicleId)
        {
            var result = _repairHistoryService.GetVehicleById(vehicleId);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult AddRepair([FromBody] RepairHistory repair)
        {
            if (repair.VehicleId <= 0)
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "VehicleId must be greater than zero."
                });
            }
            if (string.IsNullOrWhiteSpace(repair.DescriptionOfRepair))
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "Description must not be empty."
                });
            }
            if (repair.RepairCost < 0)
            {
                return BadRequest(new
                {
                    error = "InvalidParameter",
                    message = "Cost cannot be negative."
                });
            }
            var created = _repairHistoryService.AddRepair(repair);
            return CreatedAtAction(
            nameof(GetRepairs),
            new { vehicleId = created.VehicleId },
            created
            );
        }


        [HttpGet("crash")]
        public IActionResult Crash()
        {
            int x = 0;
            int y = 5 / x;
            return Ok();
        }

        [HttpGet("usage")]
        public IActionResult Usage()
        {
            var key = Request.Headers["X-Api-Key"].ToString();
            if (!_usageCounts.ContainsKey(key))
                _usageCounts[key] = 0;
            _usageCounts[key]++;
            return Ok(new
            {
                clientId = key,
                callCount = _usageCounts[key]
            });
        }
    }
}
