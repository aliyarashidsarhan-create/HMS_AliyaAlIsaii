using Hotel_Management_System__HMS_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Services
{
    public  class StaffService
    {
        public static void DisplayAllStaff(List<StaffModel> staffModels)
        {
            foreach (StaffModel staff in staffModels)
            {
                Console.WriteLine("staff id :"+staff.staffId + "role "+staff.role
                    + "is On Duty "+staff.isOnDuty);
            }


        }
        public static int  FindStaffById(List<StaffModel> staffModels, string satffId)
        {
            foreach(StaffModel staff in staffModels)
            {
                if(staff.staffId == satffId)
                    return 0;
            }
            return null;
          
        }
        public static void ToggleDutyStatus(StaffModel staff)
        {
         
        }


    }
}
