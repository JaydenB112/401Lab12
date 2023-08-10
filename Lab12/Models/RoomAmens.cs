using System.ComponentModel.DataAnnotations;
using Lab12.Models;

namespace Lab12.Models
{
    public class RoomAmens
    {
        [Key]

        public int ID { get; set; }
        [Required]

        public int RoomsID { get; set; }
        [Required]

        public int AmenID { get; set; }

        public Rooms Rooms { get; set; }

        public Amenities Amenity { get; set; }
    }
}
