using System;
using System.Collections.Generic;
using System.Text;


namespace FlexWheelsNew.Models
{
    public class Customer
    {
        public Customer()
        {
            Bookings = new List<Bookings>();
        }


        public int SocialSecurityNumber { get; set; }
        public string phone_number { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public int CID { get; set; }
        public ICollection<Bookings> Bookings { get; set; }

    }
}
