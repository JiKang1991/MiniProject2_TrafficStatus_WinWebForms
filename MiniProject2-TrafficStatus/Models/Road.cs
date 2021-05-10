using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProject2_TrafficStatus.Models
{
    public class Road
    {
        public int id { get; set; }
        public int roadNumber { get; set; }
        public string roadName { get; set; }
        public int startLocX { get; set; }
        public int startLocY { get; set; }
        public int finishLocX { get; set; }
        public int finishLocY { get; set; }
    }
}