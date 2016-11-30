using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tally.Models
{
    public class BusStops
    {
        public string name {get;set;}
        public string location { get; set; }
        public string distance { get; set; }

        public BusStops(string name, string location, string distance)
        {
            this.name = name;
            this.location = location;
            this.distance = distance;
        }
    }
}
