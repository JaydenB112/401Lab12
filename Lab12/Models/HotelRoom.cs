using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class HotelRoom
    {
        [Key]
        
        public int Id { get; set; }

        [Required]
        public int RoomID { get; set; }

        [Required]
        public int HotelID { get; set; }

        [Required]
        public double Price { get; set; }

        public Hotel Hotel { get; set; }

        public Rooms rooms { get; set; }
    }
}
