using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_
{
    public  class HotelContext
    {
        public List<RoomModel> rooms { get; set; }
        public List<GuestModel> guests { get; set; }
        public List<BookingModel> bookings { get; set; }
        public List<ReviewModel> reviews { get; set; }
        public List<StaffModel> staff { get; set; }

    }
}
