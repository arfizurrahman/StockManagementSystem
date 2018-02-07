using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class ItemGateway : Gateway
    {
        public SqlDataAdapter GetCategories()
        {
            Query = "SELECT * FROM Category";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            SqlDataAdapter sda = new SqlDataAdapter(Command); 
            Connection.Close();

            return sda;
        }

        public SqlDataAdapter GetCompanies()
        {
            Query = "SELECT * FROM Company";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            SqlDataAdapter sda = new SqlDataAdapter(Command);
            Connection.Close();

            return sda;
        }

        public bool IsItemExistes(string itemName)
        {
            Query = "SELECT * FROM Item WHERE Name = '" + itemName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public int SaveItem(Item aItem)
        {
            Query = "INSERT INTO Item (CategoryId, CompanyId, Name, ReorderLevel) VALUES('" + aItem.CategoryId + "','" + aItem.CompanyId + "','" + aItem.Name + "','" + aItem.ReorderLevel + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}
