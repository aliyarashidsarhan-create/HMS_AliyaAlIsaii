using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Services
{
    public class BookingService
    {
        public static void DisplayAllBookings(List<BookingModel> ngModel)
        {
            foreach (BookingModel booking in ngModel)
            {
                Console.WriteLine("Booking Id " + booking.bookingId + "guest Id " + booking.guestId +
                   " roomNumber " + booking.roomNumber + "status " + booking.status +
                 "total Price " + booking.totalPrice);
            }
        }
        public static BookingModel FindBookingById(List<BookingModel> bookings, string bookingId)
        {
            foreach (BookingModel booking in bookings)
            {
                if (booking.bookingId == bookingId)
                {
                    return booking;
                }
            }
            return null;
        }
        public static bool CancelBooking(BookingModel booking)
        {
            if (booking.status == "cancelled")
            {
                return false;
            }
            booking.status = "cancelled";
            return true;
        }
        public static bool CompleteBooking(BookingModel booking ,RoomModel room)
        {
            if (booking.status !="Confirmed")
            {
             return false;
            }
            booking.status = "completed";
            room.isAvailable = true;
            return true;
        }
    }
}
