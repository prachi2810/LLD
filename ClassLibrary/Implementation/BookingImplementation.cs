using System;
using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Implementation
{
    public class BookingImplementation : IBooking
    {
        public List<Booking> _bookings = new List<Booking>();
        public IParking _parking;
        public BookingImplementation(IParking parking)
        {
            _bookings = new List<Booking>();
            _parking = parking;
        }

        public void BookParking(string userName, string parkingName, VehicleType vehicleType)
        {
           if(!IsBookingAvailable(userName, vehicleType))
            {
                Console.WriteLine($"Booking already exists for {userName} at {parkingName}.");
                return;
            }

            var parking= _parking.GetParkingDetails(parkingName);
            
            if (parking == null || !_parking.IsAvailable(parkingName, vehicleType))
            {
                Console.WriteLine($"Parking {parkingName} is not available.");
                return;
            }
            _bookings.Add(new Booking
            {
                User = new User { UserName = userName },
                Vehicle = new Vehicle { VehicleType = vehicleType }
            });

           
            Console.WriteLine($"Booking successful for {userName} at {parkingName} for vehicle type {vehicleType}.");
           
        }

        public void CancelBooking(string userName, string parkingName)
        {
            var booking = _bookings.FirstOrDefault(b => b.User.UserName == userName && b.ParkingName == parkingName);
            if (booking != null)
            {
                var parking = _parking.GetParkingDetails(parkingName);
                parking.FreeSpot(booking.Vehicle.VehicleType); // ✅ Correct property access
                _bookings.Remove(booking);
                Console.WriteLine($"Booking for {userName} at {parkingName} has been cancelled.");
            }
            else
            {
                Console.WriteLine($"No booking found for {userName} at {parkingName}.");
            }
        }


        public Booking GetBookingDetails(string userName, string parkingName)
        {
            return _bookings.FirstOrDefault(b => b.User.UserName == userName && b.ParkingName == parkingName);
        }


        public bool IsBookingAvailable(string parkingName, VehicleType vehicleType)
        {
            var parking = _parking.GetParkingDetails(parkingName);
            if (parking == null)
            {
                Console.WriteLine($"Parking '{parkingName}' not found.");
                return false;
            }

            if (parking.AvailableSpots == null)
            {
                Console.WriteLine($"Available spots info missing for '{parkingName}'.");
                return false;
            }

            return parking.AvailableSpots.TryGetValue(vehicleType, out int spots) && spots > 0;
        }



        public void UpdateBooking(string userName, string parkingName, VehicleType vehicleType)
        {
            CancelBooking(userName, parkingName);
            BookParking(userName, parkingName, vehicleType);
        }
    }
}