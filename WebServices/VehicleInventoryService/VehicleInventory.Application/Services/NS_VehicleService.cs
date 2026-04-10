using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Application.DTOs;
using VehicleInventory.Application.Interfaces;
using VehicleInventory.Domain.Entities;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exception;

namespace VehicleInventory.Application.Services
{
    public class NS_VehicleService
    {
        private readonly NS_IVehicleRepo _vehicleRepo;

        public NS_VehicleService(NS_IVehicleRepo vehicleRepo)
        {
            _vehicleRepo = vehicleRepo;
        }

        public async Task<NS_VehicleDto> CreateVehicleAsync(NS_CreateVehicleRequest request, CancellationToken ct = default)
        {
            var vehicle = new Vehicle(Guid.NewGuid(), request.VehicleCode, request.LocationId, request.VehicleType);
            await _vehicleRepo.AddAsync(vehicle, ct);
            return ToDto(vehicle);
        }

        public async Task<NS_VehicleDto?> GetVehicleByIdAsync(Guid id, CancellationToken ct = default)
        {
            var v = await _vehicleRepo.GetByIdAsync(id, ct);
            return v == null ? null : ToDto(v);
        }

        public async Task<List<NS_VehicleDto>> GetAllVehiclesAsync(CancellationToken ct = default)
        {
            var list = await _vehicleRepo.GetAllAsync(ct);
            return list.Select(ToDto).ToList();
        }

        public async Task<bool> UpdateVehicleStatusAsync(Guid id, VehicleStatus status, CancellationToken ct = default)
        {
            var v = await _vehicleRepo.GetByIdAsync(id, ct);
            if (v == null) throw new DomainException("Vehicle not found.");

            switch (status)
            {
                case VehicleStatus.Available: v.MarkAvailable(); 
                    break;
                case VehicleStatus.Reserved: v.MarkReserved(); 
                    break;
                case VehicleStatus.Rented: v.MarkRented();
                    break;
                case VehicleStatus.Serviced: v.MarkServiced();
                    break;
                default: throw new DomainException("Invalid status.");
            }

            await _vehicleRepo.UpdateAsync(v, ct);
            return true;
        }

        public async Task<bool> DeleteVehicleAsync(Guid id, CancellationToken ct = default)
        {
            var v = await _vehicleRepo.GetByIdAsync(id, ct);
            await _vehicleRepo.DeleteAsync(v, ct);
            if (v == null) throw new DomainException("Vehicle not found.");
            return true;
        }
        private static NS_VehicleDto ToDto(Vehicle v)
            => new(v.Id, v.VehicleCode, v.LocationId, v.VehicleType, v.Status);
    }
}
