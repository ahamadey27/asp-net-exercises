using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TollAppWebApp.Models;

namespace TollAppWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<TollBooth> TollBooths { get; set; }
        public DbSet<TollRecord> TollRecords { get; set; }
        
    }
}