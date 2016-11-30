using System;
using System.Collections.Generic;
using System.Linq;

namespace Bitcoin.Models
{
    public class RawTicker
    {
        public string volume { get; set; }
        public string last { get; set; }
        public string bid { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string ask { get; set; }
    }

    public class Ticker
    {
        public double volume { get; set; }
        public double last { get; set; }
        public double bid { get; set; }
        public double high { get; set; }
        public double low { get; set; }
        public double ask { get; set; }
    }
}