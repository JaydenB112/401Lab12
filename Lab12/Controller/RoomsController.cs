using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12.Data;
using Lab12.Models;

namespace Lab12
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly AsyncInnContext _context;

        public RoomsController(AsyncInnContext context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rooms>>> GetRooms_1()
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            return await _context.Rooms
                    .Include(r => r.HotelRooms)
                    .ThenInclude(hr=> hr.Hotel)
                    .Include(room => room.RoomAmens)
                    .ThenInclude(RoomAmens => RoomAmens.Amenity)
                    .ToListAsync();
        }

        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rooms>> GetRooms(int id)
        {
          if (_context.Rooms == null)
          {
              return NotFound();
          }
            var rooms = await _context.Rooms.FindAsync(id);

            if (rooms == null)
            {
                return NotFound();
            }

            return rooms;
        }

        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRooms(int id, Rooms rooms)
        {
            if (id != rooms.ID)
            {
                return BadRequest();
            }

            _context.Entry(rooms).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Rooms>> PostRooms(Rooms rooms)
        {
          if (_context.Rooms == null)
          {
              return Problem("Entity set 'AsyncInnContext.Rooms_1'  is null.");
          }
            _context.Rooms.Add(rooms);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRooms", new { id = rooms.ID }, rooms);
        }




        [HttpPost]
        public async Task<IActionResult> PostAmenityToRoom(int ID, int RoomsID)
        {
            if (_context.RoomAmens == null)
            {
                return Problem("Entity set 'AsyncInnContext.Amenities'  is null.");
            }


            var amenity = await _context.Amenities.FindAsync(ID);
            if (amenity == null)
            {
                return Problem("No amenity with that ID exists");
            }

            var room = await _context.Rooms.FindAsync(ID);
            if (room == null)
            {
                return Problem("No room with that ID exists");
            }

            RoomAmens newRoomAmenity = new RoomAmens();
            try
            {
                newRoomAmenity = _context.RoomAmens.Add(new RoomAmens { ID = ID, RoomsID = RoomsID }).Entity;
            }
            catch (Exception e)
            {
                // Handle exception as needed
            }
            finally
            {
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction("PostAmenityToRoom", newRoomAmenity.ID, newRoomAmenity);
        }

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRooms(int id)
        {
            if (_context.Rooms == null)
            {
                return NotFound();
            }
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(rooms);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomsExists(int id)
        {
            return (_context.Rooms?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
