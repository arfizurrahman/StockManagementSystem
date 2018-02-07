using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace StockManagementSystem.Gateway
{
    class Gateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }
        public string Query { get; set; }

        private static string connectionString = @"Data Source=DESKTOP-JLGG6K6\SQLEXPRESS;Initial Catalog=StockManagementSystemDB;Integrated Security=True";

        public Gateway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}
