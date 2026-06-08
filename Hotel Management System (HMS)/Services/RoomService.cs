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
        public static void DisplayAllRooms(List<RoomModel> roomM)
        {
          
         foreach (RoomModel Room in RoomM)
            {
             Console.WriteLine(Room.roomNumber);
             Console.WriteLine(Room.roomType);
             Console.WriteLine(Room.pricePerNight);
             Console.WriteLine(Room.isAvailable);


            }
        }
        public static void DisplayAvailableRooms(List<RoomModel> rooms)
        {foreach (RoomModel Room in rooms)
            {
              if(Room.isAvailable)
                {
                    Console.WriteLine(Room.roomNumber);
                    Console.WriteLine(Room.roomType);
                    Console.WriteLine(Room.pricePerNight);
                }
            }

        }
        public static void FindRoomByNumber(List<RoomModel> room , string roomNumber)
        {
            foreach (RoomModel Room in room)
            {
                if (Room.roomNumber == roomNumber)
                {
                    return Room;
                }
            }
            return null;
        }
       public static double CalculateTotalPrice(RoomModel room ,int nights )
        {
          return pricePerNight * nights;
        }
    }
}

