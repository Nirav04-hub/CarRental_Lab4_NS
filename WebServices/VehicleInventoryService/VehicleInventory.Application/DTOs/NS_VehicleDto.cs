using System;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Application.DTOs
{
    public record NS_VehicleDto(
        Guid Id,
        string vehicleCode,
        Guid locationId,
        string vehicleType,
        VehicleStatus status
    );
}
