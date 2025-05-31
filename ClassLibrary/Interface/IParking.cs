using System;
using ClassLibrary.Models;

namespace ClassLibrary.Interface
{
    public interface IParking
    {
            bool IsAvailable(string parkingName, VehicleType type);
            Parking GetParkingDetails(string parkingName);

             public void AddParking(Parking parking);
    }
}