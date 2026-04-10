using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Entities;
using VehicleInventory.InfrastructureNS.Persistence;

namespace VehicleInventory.InfrastructureNS.Repositories
{
    public class NS_VehicleRepository : NS_IVehicleRepo
    {

        private readonly NS_InventoryDbContext _Dbcontext;

        public NS_VehicleRepository(NS_InventoryDbContext dbContext)
        {
            _Dbcontext = dbContext;
        }

        public async Task AddAsync(Vehicle vehicle, CancellationToken ct = default)
        {
            await _Dbcontext.Vehicles.AddAsync(vehicle, ct);
            await _Dbcontext.SaveChangesAsync(ct);
        }

        public async Task DeleteAsync(Vehicle vehicle, CancellationToken ct = default)
        {
            _Dbcontext.Vehicles.Remove(vehicle);
            await _Dbcontext.SaveChangesAsync(ct);
        }

        public  async Task<List<Vehicle>> GetAllAsync(CancellationToken ct = default)
        {
            return await _Dbcontext.Vehicles.ToListAsync(ct);
        }

        public async Task<Vehicle?> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            return await _Dbcontext.Vehicles.FirstOrDefaultAsync(v => v.Id == id, ct);
        }

        public async Task UpdateAsync(Vehicle vehicle, CancellationToken ct = default)
        {
            _Dbcontext.Vehicles.Update(vehicle);
            await _Dbcontext.SaveChangesAsync(ct);
        }
    }
}
