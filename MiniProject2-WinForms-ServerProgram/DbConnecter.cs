using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject2_WinForms_ServerProgram
{
    class DbConnecter
    {
        SqlConnection sqlConnection = new SqlConnection();
        SqlCommand sqlCommand = new SqlCommand();

        public DbConnecter(string connectionString)
        {
            sqlConnection.ConnectionString = connectionString;
            sqlConnection.Open();
            sqlCommand.Connection = sqlConnection;
        }

        public object RunSql(string sql)
        {
            string trimedSql = sql.Trim();
            sqlCommand.CommandText = trimedSql;

            if (GetToken(0,trimedSql,' ').ToUpper().Equals("SELECT"))
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                DataTable dataTable = new DataTable();
                dataTable.Load(sqlDataReader);
                sqlDataReader.Close();
                return dataTable;
            }
            else
            {
                return sqlCommand.ExecuteNonQuery();
            }
        }

        public object Get(string sql)
        {
            string trimedSql = sql.Trim();
            sqlCommand.CommandText = trimedSql;
            return sqlCommand.ExecuteScalar();
        }

        private string GetToken(int index, string source, char separator)
        {
            string[] splitedSource = source.Split(separator);
            return splitedSource[index];
        }
    }
}
