using System;
using ClassLibrary.Models;

namespace ClassLibrary.Interface
{
    public interface IBooking
    {
         void BookParking(string userName, string parkingName, VehicleType vehicleType);

         void CancelBooking(string userName, string parkingName);

         Booking GetBookingDetails(string userName, string parkingName);

        public bool IsBookingAvailable(string parkingName, VehicleType vehicleType);
        
         void UpdateBooking(string userName, string parkingName, VehicleType vehicleType);
        
    }
}