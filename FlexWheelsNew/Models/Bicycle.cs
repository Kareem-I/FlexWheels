using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexWheelsNew.Models
{
    public class Bicycle
    {
        public Bicycle()
        {
            Bicycle_bookings = new List<Bicycle_bookings>();
        }


        public int bicycle_id { get; set; }

        public string bicycle_brandname { get; set; }
        public string wheeltype { get; set; }

        public string bicycleprice { get; set; }
        public Store Store { get; set; }
        public int StoreID { get; set; }

       public ICollection<Bicycle_bookings> Bicycle_bookings { get; set; }
       


    }
}

