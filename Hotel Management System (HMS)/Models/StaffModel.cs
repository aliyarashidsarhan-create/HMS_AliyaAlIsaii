using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Models
{
    public class StaffModel
    {
        public string staffId { get; set; }
        public string fullName { get; set; }
        public string role {  get; set; }
        public string email { get; set; }
        public bool isOnDuty { get; set; }
        public static string hotelName { get; set; } = "Grand Codeline Hotel";
    }
}
