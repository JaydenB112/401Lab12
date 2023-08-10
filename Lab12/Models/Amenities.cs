using System.ComponentModel.DataAnnotations;

namespace Lab12.Models
{
    public class Amenities
    {
        [Key]

        public int ID { get; set; }
        [Required]

        public string NameofAmen { get; set; }

        public List<RoomAmens> RoomAmens { get; set;}

       
    }
}
