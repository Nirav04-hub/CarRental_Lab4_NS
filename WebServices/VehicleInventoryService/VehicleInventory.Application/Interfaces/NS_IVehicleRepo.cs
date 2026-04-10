using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Entities;

namespace VehicleInventory.Application.Interfaces
{
    public interface NS_IVehicleRepo
    {
        public Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken ct = default);
        public Task<List<Vehicle>> GetAllAsync(CancellationToken ct = default);
        public Task AddAsync(Vehicle vehicle, CancellationToken ct = default);
        public Task UpdateAsync(Vehicle vehicle, CancellationToken ct = default);
        public Task DeleteAsync(Vehicle vehicle, CancellationToken ct = default);
    }
}
