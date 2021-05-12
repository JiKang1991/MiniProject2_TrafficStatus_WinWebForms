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

        public Dictionary<string, object> GetFabricationValue(int id)
        {
            
            Dictionary<string, object> dicFabricationValue = new Dictionary<string, object>();
            
            DbConnecter dbConnecter = new DbConnecter(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30");
                  

            string sql = $"SELECT f.r_id, f.avg_speed, f.count, r.r_name, r.r_out_cross, r.r_in_cross FROM " +
                        $"(SELECT r_id, AVG(ts_speed) AS avg_speed , COUNT(id) AS count FROM traffic_status WHERE r_id = {id} GROUP BY r_id) f JOIN road_data r " +
                        $"ON f.r_id = r.r_id WHERE r.r_id = {id}";

            DataTable dataTable = (DataTable)dbConnecter.RunSql(sql);
                        

            for (int i = 0; i < dataTable.Columns.Count; i++) {
                dicFabricationValue.Add(dataTable.Columns[i].ToString(), dataTable.Rows[0].ItemArray[i]);
            }
            
            return dicFabricationValue;     
            
        }

        public List<string> GetRoadName()
        {
            List<string> listRoadName = new List<string>();
            DbConnecter dbConnecter = new DbConnecter(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\kosta\C#\trafficStatus.mdf;Integrated Security=True;Connect Timeout=30");

            string sql = "SELECT r_name FROM road_data";

            DataTable dataTable = (DataTable)dbConnecter.RunSql(sql);

            for(int i = 0; i < dataTable.Rows.Count; i++)
            {
                listRoadName.Add(dataTable.Rows[i].ItemArray[0].ToString());
            }

            return listRoadName;
        }
    }
}