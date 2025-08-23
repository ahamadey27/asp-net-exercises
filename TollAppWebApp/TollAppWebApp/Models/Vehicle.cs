using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TollAppWebApp.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? LicensePlate { get; set; }
        public string? OwnerName { get; set; }
    }
}