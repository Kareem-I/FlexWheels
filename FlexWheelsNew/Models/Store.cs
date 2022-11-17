using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlexWheelsNew.Models
{
    public class Store
    {

        public int StoreID { get; set; }
        public string StoreLocation { get; set; }
        public ICollection<Bicycle> Bicycle { get; set; }
    }
}
