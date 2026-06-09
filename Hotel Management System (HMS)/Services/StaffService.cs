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
                Console.WriteLine("staff id :"+staff.staffId +"Full Name"+staff.fullName+ "role "+staff.role
                    + "is On Duty "+staff.isOnDuty);
            }


        }
        public static StaffModel FindStaffById(List<StaffModel> staffModels, string satffId)
        {
            foreach(StaffModel staff in staffModels)
            {
                if(staff.staffId == satffId)
                {
                    return staff;
                }
                   
            }
            return null;
          
        }
        public static void ToggleDutyStatus(StaffModel staff)
        {
            if (staff.isOnDuty)
            {
                staff.isOnDuty = false;
            }
            else
            {
                staff.isOnDuty = true;
            }
            Console.WriteLine(" new Status :"+staff.isOnDuty);

        }


    }
}
