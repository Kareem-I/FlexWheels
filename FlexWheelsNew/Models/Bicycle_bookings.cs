using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexWheelsNew.Models
{
    public class Bicycle_bookings
    {

        public int bicycle_id { get; set; }
        public Bicycle Bicycle { get; set; }
        public int booking_id { get; set; }
        public Bookings Bookings { get; set; }
        public int CID { get; set; }
        public Customer Customer { get; set; }

    }
}

