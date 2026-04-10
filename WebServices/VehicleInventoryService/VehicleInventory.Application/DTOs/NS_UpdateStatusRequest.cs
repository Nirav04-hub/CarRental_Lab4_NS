using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleInventory.Domain.Enums;

namespace VehicleInventory.Application.DTOs
{
    public class NS_UpdateStatusRequest
    {
        [Required]
        public VehicleStatus status { get; set; }

    }
}
