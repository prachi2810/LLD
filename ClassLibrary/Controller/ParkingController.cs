using System;
using ClassLibrary.Implementation;
using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Controller
{
    public class ParkingController
    {
        private readonly IParking _parkingService;

        public ParkingController(IParking parkingService)
        {
            _parkingService = parkingService;
        }

        public Parking GetParkingDetails(string parkingName)
        {
            return _parkingService.GetParkingDetails(parkingName);
        }

        public bool IsSpotAvailable(string parkingName, VehicleType vehicleType)
        {
            return _parkingService.IsAvailable(parkingName, vehicleType);
        }

        public void AddParking(Parking parking)
        {
            _parkingService.AddParking(parking);
        }
    }
}

