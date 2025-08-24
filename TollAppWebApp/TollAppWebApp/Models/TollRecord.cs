using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TollAppWebApp.Models
{
    public class TollRecord
    {
        public int Id { get; set; } //primary key
        public int VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int TollBoothId { get; set; }
        public DateTime TimeStamp { get; set; } //when vehicle passes toll
        public decimal Amount { get; set; }
    }
}