using System;
using Lab12.Models;
using Microsoft.EntityFrameworkCore;
namespace Lab12.Data
{
    public class AsyncInnContext : DbContext
    {
        public DbSet<Amenities> Amenities { get; set; } 
        public DbSet<RoomAmens> RoomAmens { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Hotel> Hotel { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }
        public AsyncInnContext(DbContextOptions<AsyncInnContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Amenities>().HasData(new Amenities
            { ID = 1, NameofAmen = "A/C" });
            modelBuilder.Entity<Rooms>().HasData(new Rooms
            { ID = 1, Layout = 0, Name = "Basic Room" },
            new Rooms
            { ID = 2, Layout = 1, Name = "Basic Single Room" },
            new Rooms
            { ID = 3, Layout = 2, Name = "Basic Double Room" });
            modelBuilder.Entity<Hotel>().HasData(new Hotel
            {
                ID = 1,
                Address = "123 Sesame St",
                City = "Memphis",
                State = "TN",
                Name = "Elmo's Hotel",
                Phone = "555-555-5555"
            });
            //reference tables
            modelBuilder.Entity<RoomAmens>().HasData(new RoomAmens
            { ID = 1, AmenID = 1, RoomsID = 1 });
            modelBuilder.Entity<HotelRoom>().HasData(new HotelRoom
            { Id = 1, HotelID = 1, RoomID = 1, Price = 100.99 });
            
        }

    }
}
