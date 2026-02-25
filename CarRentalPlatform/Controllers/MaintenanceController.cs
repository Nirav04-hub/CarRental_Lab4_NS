using CarRentalPlatform.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalPlatform.Controllers
{
    public class MaintenanceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MaintenanceController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult History()
        {
            return View(new List<RepairHistoryViewModel>());
        }

        [HttpPost]
        public async Task<IActionResult> History(int vehicleId)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");

            var repairs = await client.GetFromJsonAsync<List<RepairHistoryViewModel>>(
                $"api/maintenance/vehicles/{vehicleId}/repairs"
            );

            return View(repairs ?? new List<RepairHistoryViewModel>());
        }

        
        public async Task<IActionResult> usage()
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var result = await client.GetFromJsonAsync<UsageViewModel>("api/Maintenance/usage");
            return View(result);
        }

      
        public async Task<IActionResult> Transfer(int fromId, int toId, decimal amount)
        {
            var client = _httpClientFactory.CreateClient("MaintenanceApi");
            var response = await client.PostAsync(
            $"api/Maintenance/transfer?fromId={fromId}&toId={toId}&amount={amount}",
            null);
            var content = await response.Content.ReadAsStringAsync();
            ViewBag.Result = content;
            return View();
        }
    }
}
