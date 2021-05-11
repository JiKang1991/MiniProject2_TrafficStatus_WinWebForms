using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniProject2_TrafficStatus.Models
{
    public class Traffic_Status
    {
        public int id { get; set; }
        public int r_id { get; set; }
        public decimal ts_speed { get; set; }
        public string ts_loc_x { get; set; }
        public string ts_loc_y { get; set; }
        public DateTime time { get; set; }
    }
}