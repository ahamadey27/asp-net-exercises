using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TollAppWebApp.Models;

namespace TollAppWebApp.Data
{
    public class TollContext : DbContext
    {
        public TollContext(DbContextOptions<TollContext> options) : base(options) { }
        
        public DbSet<TollRecord> TollRecords { get; set; } // DbSet represents the table of toll records
    }
}