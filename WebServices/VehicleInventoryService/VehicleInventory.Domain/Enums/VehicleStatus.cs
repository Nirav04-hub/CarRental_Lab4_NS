using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Domain.Enums
{
    public enum VehicleStatus
    {
        Available = 0,
        Reserved = 1,
        Rented = 2,
        Serviced = 3,
    }
}
