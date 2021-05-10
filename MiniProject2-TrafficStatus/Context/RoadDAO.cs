using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniProject2_TrafficStatus.Context
{
    public class RoadDAO : DbContext
    {
        public DbSet<RoadDAO> roadDAOs { get; set; }
        public RoadDAO() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30")
        {

        }

        public System.Data.Entity.DbSet<MiniProject2_TrafficStatus.Models.Road> Roads { get; set; }
    }
}