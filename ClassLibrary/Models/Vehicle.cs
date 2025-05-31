using System;

namespace ClassLibrary.Models
{
    public class Vehicle
    {
        public string VehicleNumber { get; set; }

        public VehicleType VehicleType { get; set; }        

        public DateTime EntryTime { get; set; }

        public DateTime ExitTime { get; set; }


    }
}