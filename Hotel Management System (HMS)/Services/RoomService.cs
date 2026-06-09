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
        public static void DisplayAllRooms(List<RoomModel> room)
        {
          
         foreach (RoomModel rooms in room)
            {
             Console.WriteLine(rooms.roomNumber);
             Console.WriteLine(rooms.roomType);
             Console.WriteLine(rooms.pricePerNight);
             Console.WriteLine(rooms.isAvailable);


            }
        }
        public static void DisplayAvailableRooms(List<RoomModel> rooms)
        {foreach (RoomModel Rooms in rooms)
            {
              if(Rooms.isAvailable)
                {
                    Console.WriteLine(Rooms.roomNumber);
                    Console.WriteLine(Rooms.roomType);
                    Console.WriteLine(Rooms.pricePerNight);
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

