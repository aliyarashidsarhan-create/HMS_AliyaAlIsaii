using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Models
{
    public static class RoomModel
    {
       public static string roomNumber { get; set; }
        public static string roomType { get; set; }
        public static double pricePerNight { get; set; }
        public static bool isAvailable { get; set; }
        public static int floor {  get; set; }
    }
}
