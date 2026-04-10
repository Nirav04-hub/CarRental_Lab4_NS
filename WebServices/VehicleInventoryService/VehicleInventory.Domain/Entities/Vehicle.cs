using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Enums;
using VehicleInventory.Domain.Exception;

namespace VehicleInventory.Domain.Entities
{
    public class Vehicle
    {
        public Guid Id { get; private set; }
        public string VehicleCode { get; private set; }
        public Guid LocationId { get; private set; }
        public string VehicleType { get; private set; }

        public VehicleStatus Status { get; private set; }

        private Vehicle() { }

        public Vehicle(Guid id, string vehicleCode, Guid locationId, string vehicleType)
        {
            if (id == Guid.Empty)
            {
                throw new DomainException("Vehicle Id cannot be empty.");
            }
            if (string.IsNullOrWhiteSpace(vehicleCode)) {
                throw new DomainException("VehicleCode is required.");
            }
            if (vehicleCode.Length > 50) {
                throw new DomainException("VehicleCode max length is 50.");
            }
            if (locationId == Guid.Empty) { 
                throw new DomainException("LocationId cannot be empty."); 
            }
            if (string.IsNullOrWhiteSpace(vehicleType)) { 
                throw new DomainException("VehicleType is required.");
            }
            if (vehicleType.Length > 50) { 
                throw new DomainException("VehicleType max length is 50.");
            }


            Id = id;
            VehicleCode = vehicleCode.Trim();
            LocationId = locationId;
            VehicleType = vehicleType.Trim();
            Status = VehicleStatus.Available;
        }

        public void MarkAvailable()
        {
            if (Status == VehicleStatus.Reserved)
            {
                throw new DomainException("Reserved vehicle cannot be marked Available ");
            }

            Status = VehicleStatus.Available;
        }

        public void MarkReserved()
        {
            if (Status == VehicleStatus.Rented)
            {
                throw new DomainException("A rented vehicle cannot be reserved.");
            }

            if (Status == VehicleStatus.Serviced)
            {
                throw new DomainException("A vehicle under service cannot be reserved.");
            }

                Status = VehicleStatus.Reserved;
        }

        public void MarkRented()
        {
            if (Status == VehicleStatus.Rented)

            {
                throw new DomainException("Vehicle is already rented.");
            }

            if (Status == VehicleStatus.Reserved)

            {
                throw new DomainException("Reserved vehicle cannot be rented.");
            }
            if (Status == VehicleStatus.Serviced)
            {
                throw new DomainException("Vehicle under service cannot be rented.");
            }
            Status = VehicleStatus.Rented;
        }

        public void MarkServiced()
        {
            if (Status == VehicleStatus.Rented)
            {
                throw new DomainException("Rented vehicle cannot be sent to service.");
            }

            Status = VehicleStatus.Serviced;
        }

        
        public void ReleaseReservation()
        {
            if (Status != VehicleStatus.Reserved)
            { 
                throw new DomainException("Vehicle is not reserved, cannot release reservation.");
            }
            Status = VehicleStatus.Available;
        }

    }
}
