using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Services
{
    public static class GuestService
    {
        public static void DisplayAllGuests(List<GuestModel> guests)
        {
            
            foreach (GuestModel guest in guests)
            {
                Console.WriteLine($"Guste Id :{guest.guestId}");
                Console.WriteLine($"Full Name is :{guest.fullName}");
                Console.WriteLine($"Email is :{guest.email}");
                Console.WriteLine($"Phone Number :{guest.phoneNumber}");
            }
        }
        public static GuestModel FindGuestById(List<GuestModel> guests, string guestId)
        {
            foreach (GuestModel guest in guests)
            {
                if(guest.guestId == guestId)
                { 
                    return guest;
                }
            }
            return null;
        }
        
    }
}
