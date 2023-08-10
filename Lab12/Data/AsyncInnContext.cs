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


        public AsyncInnContext(DbContextOptions<AsyncInnContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                


        }

    }
}
