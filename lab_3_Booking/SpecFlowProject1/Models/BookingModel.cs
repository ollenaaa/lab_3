using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Models
{
    public class BookingModel
    {
        public BookingDates bookingdates;

        public string firstname { get; set; }
        public string lastname { get; set; }
        public int totalprice { get; set; }
        public bool depositpaid { get; set; }
        public class BookingDates
        {
            public string checkin { get; set; }
            public string checkout { get; set; }
        }
        public string additionalneeds { get; set; }
    }
}
