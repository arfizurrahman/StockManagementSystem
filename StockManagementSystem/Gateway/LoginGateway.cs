using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class LoginGateway : Gateway
    {
        public bool CheckLogin(User aUser)
        {
            Query = "SELECT * FROM Users WHERE UserName = '" + aUser.UserName + "' AND Password = '"+aUser.Password+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }
    }
}
