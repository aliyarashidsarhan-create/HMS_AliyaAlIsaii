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
            if (booking.bookingReviews.Count == 0)
            {
                Console.WriteLine("No reviews for this booking.");
                return;
            }
            foreach(ReviewModel review in booking.bookingReviews)
            {
                Console.WriteLine($"Rating: "+review.rating);
                Console.WriteLine($"Comment: "+review.comment);
              
            }

        }
    }
}
