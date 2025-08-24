using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TollAppWebApp.Models;
using TollAppWebApp.Data;
using Microsoft.EntityFrameworkCore;

namespace TollAppWebApp.Controllers
{
    //API controller, where base route is api/tollrecords (uses controller's class name minus "Controller" to form route)
    [Route("api/[controller]")]
    [ApiController]
    public class TollRecordsController : ControllerBase
    {
        private readonly TollContext _context; 
        
        //inject TollContext via constructor to access database 
        public TollRecordsController(TollContext context)
        {
            _context = context;
        }

        //GET api/tollrecords
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TollRecord>>> GetTollRecords()
        {
            // Retrieve all toll records from the database
            return await _context.TollRecords.ToListAsync();
        }

        // GET: api/tollrecords/5
        //returns a single record or 404 if not found
        [HttpGet("{id}")]
        public async Task<ActionResult<TollRecord>> GetTollRecord(int id)
        {
            var record = await _context.TollRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();  // return 404 if not found
            }
            return record;  // returns 200 with the record
        }

        // POST: api/tollrecords
        // Accept a DTO that contains a license plate (or vehicleId) plus amount and optional timestamp
        public class CreateTollRecordDto
        {
            public int? VehicleId { get; set; }
            public string? LicensePlate { get; set; }
            public int TollBoothId { get; set; }
            public DateTime? TimeStamp { get; set; }
            public decimal Amount { get; set; }
        }

        [HttpPost]
        public async Task<ActionResult<TollRecord>> CreateTollRecord(CreateTollRecordDto dto)
        {
            Vehicle? vehicle = null;

            if (dto.VehicleId.HasValue)
            {
                vehicle = await _context.Vehicles.FindAsync(dto.VehicleId.Value);
            }

            if (vehicle == null && !string.IsNullOrWhiteSpace(dto.LicensePlate))
            {
                vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.LicensePlate == dto.LicensePlate);
            }

            // If still null and a license plate was provided, create a new Vehicle
            if (vehicle == null && !string.IsNullOrWhiteSpace(dto.LicensePlate))
            {
                vehicle = new Vehicle { LicensePlate = dto.LicensePlate };
                _context.Vehicles.Add(vehicle);
                await _context.SaveChangesAsync();
            }

            // If we still don't have a vehicle, return BadRequest
            if (vehicle == null)
            {
                return BadRequest("VehicleId or LicensePlate must be provided.");
            }

            var record = new TollRecord
            {
                VehicleId = vehicle.Id,
                TollBoothId = dto.TollBoothId,
                TimeStamp = dto.TimeStamp ?? DateTime.UtcNow,
                Amount = dto.Amount,
                Vehicle = vehicle
            };

            _context.TollRecords.Add(record);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTollRecord), new { id = record.Id }, record);
        }

        // PUT: api/tollrecords/5  (update existing record)
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTollRecord(int id, TollRecord record)
        {
            if (id != record.Id)
            {
                return BadRequest(); // id mismatch in URL and body
            }
            // Mark the record as modified and save
            _context.Entry(record).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!_context.TollRecords.Any(e => e.Id == id))
            {
                return NotFound();
            }
            return NoContent(); // 204, indicating success with no body
        }
        
        // DELETE: api/tollrecords/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTollRecord(int id)
        {
            var record = await _context.TollRecords.FindAsync(id);
            if (record == null)
            {
                return NotFound();
            }
            _context.TollRecords.Remove(record);
            await _context.SaveChangesAsync();
            return NoContent();
        }   
    }
}