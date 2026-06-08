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
        public static void FindBookingById(List<BookingModel> Model, string bookingId)
        {
            foreach (BookingModel booking in Model)
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
            if (booking.status == cancelled)
            {
                return true;
            }
        }
        public static bool CompleteBooking(BookingModel cbooking)
        {
            if (cbooking == null)
            {

            }
        }
    }
}
