using System;

namespace ClassLibrary.Models
{
    public class Parking
    {
        public string ParkingName { get; set; }
        public int Capacity { get; set; }


        public Dictionary<VehicleType, int> AvailableSpots { get; set; }
        
        public bool HasAvailableSpot(VehicleType type)
        {
            return AvailableSpots.TryGetValue(type, out int spots) && spots > 0;
        }

        public void OccupySpot(VehicleType type)
        {
            if (HasAvailableSpot(type))
                AvailableSpots[type]--;
        }

        public void FreeSpot(VehicleType type)
        {
            if (AvailableSpots.ContainsKey(type))
                AvailableSpots[type]++;
         }
    }
}