using System;

namespace ClassLibrary.Models
{
    public class Booking
    {
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }

        public string ParkingName { get; set; } 
    }
}