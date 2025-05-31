using System;
using ClassLibrary.Implementation;
using ClassLibrary.Interface;
using ClassLibrary.Models;

namespace ClassLibrary.Controller
{

        public class BookingController
    {
        private readonly IBooking _bookingService;

        public BookingController(IBooking bookingService)
        {
            _bookingService = bookingService;
        }

        public void BookParking(string userName, string parkingName, VehicleType vehicleType)
        {
            _bookingService.BookParking(userName, parkingName, vehicleType);
        }

        public void CancelBooking(string userName, string parkingName)
        {
            _bookingService.CancelBooking(userName, parkingName);
        }

        public Booking GetBookingDetails(string userName, string parkingName)
        {
            return _bookingService.GetBookingDetails(userName, parkingName);
        }

        public void UpdateBooking(string userName, string parkingName, VehicleType newVehicleType)
        {
            _bookingService.UpdateBooking(userName, parkingName, newVehicleType);
        }

        public bool IsBookingAvailable(string parkingName, VehicleType vehicleType)
        {
            return _bookingService.IsBookingAvailable(parkingName, vehicleType);
        }
    }
    
}