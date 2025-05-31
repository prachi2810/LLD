using System;
using System.Collections.Generic;
using ClassLibrary.Models;
using ClassLibrary.Interface;
using ClassLibrary.Controller;  // Assuming controllers exist in this namespace
using ClassLibrary.Implementation; // Assuming implementations exist here

class Program
{
    static void Main(string[] args)
    {
        // Create a Parking object
        var parking = new Parking
        {
            ParkingName = "MainLot",
            Capacity = 10,
            AvailableSpots = new Dictionary<VehicleType, int>
            {
                { VehicleType.TwoWheeler, 5 },
                { VehicleType.FourWheeler, 5 }
            }
        };

        // Create implementations of interfaces
        IParking parkingService = new ParkingImplementation();
        IUser userService = new UserImplementation();
        IBooking bookingService = new BookingImplementation(parkingService);

        // Add parking to system
        parkingService.AddParking(parking);

        // Create controllers that wrap services
        var parkingController = new ParkingController(parkingService);
        var userController = new UserController(userService);
        var bookingController = new BookingController(bookingService);

        // Add user
        userController.AddUser("Prachi", 1234567890);

        // Book parking for a vehicle type
        bookingController.BookParking("Prachi", "MainLot", VehicleType.TwoWheeler);

        // Example: check if booking is available
        bool available = bookingController.IsBookingAvailable("MainLot", VehicleType.TwoWheeler);
        Console.WriteLine($"Is booking available for TwoWheeler: {available}");
    }
}
