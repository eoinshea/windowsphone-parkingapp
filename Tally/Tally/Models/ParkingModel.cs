using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tally.Models
{
    class ParkingModel
    {
        public ParkingModel(string streetName, double longtitude, double latitute)
        {
            this.latitude = latitude;
            this.longtitude = longtitude;
            this.streetName = streetName;
        }

        public string streetName { get; set; }
        public double longtitude { get; set; }
        public double latitude  { get; set; }
    }
}
