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
    [Route("api/[controller]")]
    [ApiController]
    public class TollRecordsController : ControllerBase
    {
        private readonly TollContext _context;

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
        [HttpPost]
        public async Task<ActionResult<TollRecord>> CreateTollRecord(TollRecord record)
        {
            // Set the timestamp to now if not provided (ensure some data consistency)
            if (record.TimeStamp == default)
                record.TimeStamp = DateTime.UtcNow;
            _context.TollRecords.Add(record);
            await _context.SaveChangesAsync();
            // Return 201 Created with the route to the new record
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