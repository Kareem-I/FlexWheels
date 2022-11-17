using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexWheelsNew.Models
{
    public class Bookings
    {
        //  public int bicycle_id { get; set; }

        public int booking_id { get; set; }
        public Customer Customer { get; set; }
        public string rent_date { get; set; }
        public string return_date { get; set; }
        public string price { get; set; }

    }
}