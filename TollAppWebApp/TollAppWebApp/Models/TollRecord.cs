using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace TollAppWebApp.Models
{
    public class TollRecord
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int TollBoothId { get; set; }
        public DateTime TimeStamp { get; set; }
        public decimal Amount { get; set; }
    }
}