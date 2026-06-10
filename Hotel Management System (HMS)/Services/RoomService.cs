using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Services
{
    public static class RoomService
    {
        public static void DisplayAllRooms(List<RoomModel> rooms)
        {
          
         foreach (RoomModel room in rooms)
            {
             Console.WriteLine(room.roomNumber);
             Console.WriteLine(room.roomType);
             Console.WriteLine(room.pricePerNight);
             Console.WriteLine(room.isAvailable);


            }
        }
        public static void DisplayAvailableRooms(List<RoomModel> rooms)
        {
            foreach (RoomModel room in rooms)
            {
              if(room.isAvailable== true)
                {
                    Console.WriteLine(room.roomNumber);
                    Console.WriteLine(room.roomType);
                    Console.WriteLine(room.pricePerNight);
                }
            }

        }
        public static RoomModel FindRoomByNumber(List<RoomModel> rooms , string roomNumber)
        {
            foreach (RoomModel room in rooms)
            {
                if (room.roomNumber == roomNumber)
                {
                    return room;
                }
            }
            return null;
        }
       public static double CalculateTotalPrice(RoomModel room ,int nights )
        {
          return room.pricePerNight * nights;
        }
    }
}

