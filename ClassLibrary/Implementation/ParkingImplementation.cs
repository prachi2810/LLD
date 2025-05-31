using  System;
using ClassLibrary.Interface;

namespace ClassLibrary.Models
{
    public class ParkingImplementation : IParking
    {
        private readonly List<Parking> _parkingList;

    public ParkingImplementation()
    {
        _parkingList = new List<Parking>();
    }

    public Parking GetParkingDetails(string parkingName)
    {
        return _parkingList.FirstOrDefault(p => p.ParkingName == parkingName);
    }

    public bool IsAvailable(string parkingName, VehicleType type)
    {
        var parking = GetParkingDetails(parkingName);
        return parking?.HasAvailableSpot(type) ?? false;
    }

    // Optional helper to register parking
    public void AddParking(Parking parking)
    {
        _parkingList.Add(parking);
    }
    }
}