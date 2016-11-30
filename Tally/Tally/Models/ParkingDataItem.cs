using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tally.Models
{
    public class ParkingDataItem
    {
        public string id { get; set; }
        public string name { get; set; }
        public string location { get; set; }
        public string distance { get; set; }
        public string price { get; set; }
        public string zone { get; set; }
        public string total_spaces { get; set; }
       


        public ParkingDataItem(string id ,string name,string location, string distance,string price, string zone, string total_spaces)
        {
            this.id =  id ;
            this.name  =      name;
            this.location    = location;
            this.distance       = location;
            this.price          = price;
            this.zone       = zone;
            this.total_spaces = total_spaces;    
            
        }


        

        
    }
}
