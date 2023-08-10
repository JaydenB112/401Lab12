using Lab12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab12.Models.Interfaces
{
    public interface IHotel
    {
        Task<ActionResult<IEnumerable<Hotel>>> GetHotel();
        Task<ActionResult<Hotel>> GetHotel(int id);
        
        Task<IActionResult> PutHotel(int id, Hotel hotel);
        Task<ActionResult<Hotel>> PostHotel(Hotel hotel);
        Task<IActionResult> DeleteHotel(int id);

        bool HotelExists(int id);
    }
}
