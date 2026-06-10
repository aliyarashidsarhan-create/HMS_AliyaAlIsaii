using Hotel_Management_System__HMS_.Models;
using Hotel_Management_System__HMS_.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_
{
    public class Program
    {
        public static void RegisterGuest(HotelContext context)
        {
            Console.WriteLine("Welcome to Grand Codeline Hotel");
            Console.WriteLine("Enter Guest Id ");
            string guestId = Console.ReadLine();
            Console.WriteLine("Enter Full Name ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter Email ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Phone Number ");
            string phoneNumber = Console.ReadLine();

            context.guests.Add(new GuestModel
            {
                guestId = guestId,
                fullName = fullName,
                email = email,
                phoneNumber = phoneNumber,
                guestBookings = new List<BookingModel>()
            }

                );
            EmailService.SendEmail(email, "Welcome to Grand Codeline Hotel", "Thank you for registering. We look forward to hosting you!");
            Console.WriteLine("user Register Succesfuly ");
        }
        public static void AddRoom(HotelContext context)
        {
            Console.WriteLine("Enter Room Number");
            string roomNumber = Console.ReadLine();
            Console.WriteLine("Enter Room Type");
            string roomType = Console.ReadLine();
            Console.WriteLine("Enter Price Per Night ");
            Double priceInput = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Floor Number");
            int floor = Convert.ToInt32(Console.ReadLine());

             
            context.rooms.Add(new RoomModel
            {
                roomNumber = roomNumber,
                roomType = roomType,
                pricePerNight = priceInput,
                floor = floor,
                isAvailable = true
            } );
            Console.WriteLine("Adding Room Succesfuly");

        }
        public static void DisplayAvailableRooms(HotelContext context)
        {
            RoomService.DisplayAvailableRooms(context.rooms);
            if(context.rooms.Count == 0) 
            {
                Console.WriteLine("No Room in System");
            }
        }
        public static void AddStaff(HotelContext context)
        {
            Console.WriteLine("Enter Staff Id ");
            string staffId = Console.ReadLine();
            Console.WriteLine("Enter Full Name");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter Role");
            string role = Console.ReadLine();
            Console.WriteLine("Enter Staff Email");
            string email = Console.ReadLine();

            context.staff.Add(new StaffModel
            {
                staffId = staffId,
                fullName = fullName,
                role = role,
                email = email,
                isOnDuty = true
            });
            
        }
        public static void DisplayAllStaff(HotelContext context)
        {
           StaffService.DisplayAllStaff(context.staff);
        }
        public static void BookRoom(HotelContext context)
        {
            Console.WriteLine("Enter Guest Id");
            string guestId = Console.ReadLine();
            Console.WriteLine("Enter Room Number");
            string roomNumber = Console.ReadLine();
            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);
            RoomModel room = RoomService.FindRoomByNumber(context.rooms, roomNumber);

            if (guest == null || room==null)
            {
                Console.WriteLine("Error Not Found Room or guest");
                return;
            }
            if (room.isAvailable==false)
            {
                Console.WriteLine("Room not available");
                return;
            }
            Console.WriteLine("Enter check In Date");
            string checkInDate = Console.ReadLine();
            Console.WriteLine("Enter  check Out Date");
            string checkOutDate = Console.ReadLine();
            Console.WriteLine("Enter  number Of Nights");
            int numberOfNights = Convert.ToInt32(Console.ReadLine());

            double totalPrice = RoomService.CalculateTotalPrice(room, numberOfNights);

            Console.WriteLine("Enter booking Id");
            string bookingId = Console.ReadLine();


            context.bookings.Add(new BookingModel
            {
                bookingId = bookingId,
                guestId = guestId,
                roomNumber = roomNumber,
                status="Confirmed"

            });
            room.isAvailable = false;
            guest.guestBookings.Add(new BookingModel());

            var guests = context.guests.Find(x => x.guestId == guestId);
            EmailService.SendEmail(guests.email, "Booking Confirmed", "Your booking  has been cancelled");
           
        }
        public static void CancelBooking(HotelContext context)
        {
            Console.WriteLine("Enter Booking  Id");
            string bookingId = Console.ReadLine();
           BookingModel booking= BookingService.FindBookingById(context.bookings, bookingId);
            {
                if (booking == null)
                {
                    
                    Console.WriteLine("Booking Not Found ");
                   return;
                }

                bool isCanceled = BookingService.CancelBooking(booking);
                if (isCanceled ==false)
                {
                    Console.WriteLine("Booking already cancelled");
                    return;
                }

                RoomModel room = RoomService.FindRoomByNumber(context.rooms, booking.roomNumber);
                if(room.isAvailable==null)
                {
                    room.isAvailable = true;
                }
                GuestModel guest = GuestService.FindGuestById(context.guests, booking.guestId);

            EmailService.SendEmail(guest.email, "Booking Cancelled", "Your booking "+bookingId+" has been cancelled");
        }}
        public static void AddReviewToBooking(HotelContext context)
        {
            Console.WriteLine("Enter Booking  Id");
            string bookingId = Console.ReadLine();

            BookingModel booking = BookingService.FindBookingById(context.bookings, bookingId);
            if (booking == null)
            {
                Console.WriteLine("Booking Not Found ");
                return;
            }
            if (booking.status != "Completed")
            {
                Console.WriteLine("Reviews can only be added to completed bookings.");
                return;
            }
            Console.WriteLine("Enter review Id");
            string reviewId = Console.ReadLine();
            Console.WriteLine("Enter Rating 1-5");
            int rating = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < rating; i++) 
            {

            }

            Console.WriteLine("Add Comment");
            string comment = Console.ReadLine();

            ReviewModel review = new ReviewModel
            {
                reviewId = reviewId,
                bookingId = bookingId,
                rating = rating,
                comment = comment
            };
            ReviewService.AddReview(booking, review);
            context.reviews.Add(review);

            EmailService.SendEmail(email, "Thank You for Your Review", "We appreciate your feedback! Rating:" [rating]+"/5");
        }
        public static void ToggleStaffDuty(HotelContext context)
        {
            Console.WriteLine("Enter Staff Id");
            string staffId = Console.ReadLine();

            StaffModel staff = StaffService.FindStaffById(context.staff, staffId);
            if (staff == null)
            {
                Console.WriteLine("Staff Not Found ");
                return;
            }
            StaffService.ToggleDutyStatus(staff);
        }

        public static void DisplayGuestBookingHistory(HotelContext context)
        {
            Console.WriteLine("Enter Guest Id");
            string guestId = Console.ReadLine();

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);
            if (guest == null)
            {
                Console.WriteLine("Guest Not Found ");
                return;
            }
            foreach (BookingModel booking in guest.guestBookings)
            {
                Console.WriteLine($"Booking Id: {booking.bookingId}, Room Number: " +
                    $"{booking.roomNumber}, Status: {booking.status},Total Price:{booking.totalPrice}");
            }

        }

        public static void CompleteBooking(HotelContext context)
        {
            Console.WriteLine("Enter Booking Id");
            string bookingId = Console.ReadLine();
            BookingModel booking = BookingService.FindBookingById(context.bookings, bookingId);
            if(booking == null)
            {
                Console.WriteLine("Booking Not Found ");
                return;
            };
           var guest = context.guests.Find(x => x.guestId == booking.guestId);
               
            

            EmailService.SendEmail(guest.email, "Stay Completed — Share Your Experience ", "Your stay at Grand Codeline Hotel is complete. Please leave a review!");
        }

        public static void DisplayRoomReviewSummary(HotelContext context)
        {
            Console.WriteLine("Enter Room Number");
            string roomNumber = Console.ReadLine();

            RoomModel room = RoomService.FindRoomByNumber(context.rooms, roomNumber);
            if(room == null)
            {
                Console.WriteLine("Room Not Found ");
                return;
            };
        }


        public static void FullGuestProfile(HotelContext context)
        {
            Console.WriteLine("Enter Guest Id");
            string guestId = Console.ReadLine();

            GuestModel guest = GuestService.FindGuestById(context.guests, guestId);
            Console.WriteLine(guest.fullName);  


        }


        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Hotel Management System!");
            HotelContext context = new HotelContext();
            context.rooms = new List<RoomModel>();
            context.guests = new List<GuestModel>();
            context.bookings = new List<BookingModel>();
            context.reviews = new List<ReviewModel>();
            context.staff = new List<StaffModel>();

            bool exit = false;
            while (exit == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Choose an Option ");
                Console.WriteLine("1.Register Guest");
                Console.WriteLine("2.Add Room");
                Console.WriteLine("3.Display Available Rooms");
                Console.WriteLine("4.Book Room");
                Console.WriteLine("5. Cancel Booking");
                Console.WriteLine("6. Compleate Booking");
                Console.WriteLine("7. Add Review to booking");
                Console.WriteLine("8.Display Guest Booking History");
                Console.WriteLine("9.Display Room Review Summary");
                Console.WriteLine("10. FullGuestProfile");
                Console.WriteLine("11. AddStaff");
                Console.WriteLine("12.Display All Staff");
                Console.WriteLine("13.Toggle Staff Duty");
                Console.WriteLine("0. Exit");

                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        RegisterGuest(context);
                        break;

                    case 2:
                        AddRoom(context);
                        break;
                    case 3:
                        DisplayAvailableRooms(context); 
                        break;
                    case 4:
                        BookRoom(context);
                        break;
                    case 5:
                        CancelBooking(context);
                        break;
                    case 6:
                        CompleteBooking(context);
                        break;
                    case 7:
                        AddReviewToBooking(context);
                        break;
                    case 8:
                        DisplayGuestBookingHistory(context);
                        break;
                    case 9:
                        DisplayRoomReviewSummary(context);
                        break;
                    case 10:
                        FullGuestProfile(context);
                        break;
                    case 11:
                        AddStaff(context);
                        break;
                    case 12:
                        DisplayAllStaff(context);
                        break;
                    case 13:
                        ToggleStaffDuty(context);
                        break;
                    case 0:
                        exit = true;
                       
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please Try Again.");
                        break;




                }
            }
        }
    }
}