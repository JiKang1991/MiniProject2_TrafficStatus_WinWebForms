using MiniProject2_TrafficStatus.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MiniProject2_TrafficStatus.Context
{
    public class TrafficStatusDAO : DbContext
    {
        public DbSet<Traffic_Status> tsDbSet { get; set; }

        public TrafficStatusDAO() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30")
        {

        }

        public FabricationValue GetFabricationValue(int id)
        {
            try
            {
                FabricationValue fabricationValue = new FabricationValue();

                DbConnecter dbConnecter = new DbConnecter(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30");

                string sql = $"SELECT r_id, AVG(ts_speed) AS avg_speed , COUNT(id) AS count FROM traffic_status WHERE r_id = {id} GROUP BY r_id";

                DataTable dataTable = (DataTable)dbConnecter.RunSql(sql);
                

                DataRow dataRow = dataTable.Rows[0];

                fabricationValue.r_id = (int)dataRow.ItemArray[0];
                fabricationValue.avg_speed = (decimal)dataRow.ItemArray[1];
                fabricationValue.count = (int)dataRow.ItemArray[2];

                return fabricationValue;
            }
            catch (Exception e)
            {
                
                return GetFabricationValue(1);
            }
            
        }

    }
}