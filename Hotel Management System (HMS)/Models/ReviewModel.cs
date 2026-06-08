using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_Management_System__HMS_.Models
{
    public class ReviewModel
    {
        public string reviewId { get; set; }
        public string bookingId { get; set; }
        public int rating { get; set; }
        public string comment { get; set; }

    }
}
