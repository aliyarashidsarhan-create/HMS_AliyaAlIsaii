using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Services
{
    public class ReviewService
    {
     public static void AddReview(BookingModel Booking, ReviewModel Review)
        {
          Booking.bookingReviews.Add(Review);
        }
      public static void DisplayReviewsForBooking(BookingModel booking)
        {

        }
    }
}
