using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleInventory.Application.DTOs
{
    public class NS_CreateVehicleRequest
    {
        [Required, MaxLength(50)]
        public string VehicleCode { get; set; }

        [Required]
        public Guid LocationId { get; set; }

        [Required, MaxLength(50)]
        public string VehicleType { get; set; }

    }
}
