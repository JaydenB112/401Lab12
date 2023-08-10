using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Rooms
    {
        [Key]
        [Required]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public int Layout { get; set; }

        public List<HotelRoom> HotelRooms { get; set; }

        public List <RoomAmens> RoomAmens { get; set; }


    }
}
