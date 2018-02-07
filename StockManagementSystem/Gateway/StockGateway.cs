using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class StockGateway : Gateway
    {
        public SqlDataAdapter GetItems(int companyId)
        {
            Query = "SELECT Id,Name FROM Item WHERE CompanyId = '"+companyId+"'";
            Connection.Open();
            Command = new SqlCommand(Query, Connection);
            SqlDataAdapter sda = new SqlDataAdapter(Command);
            Connection.Close();

            return sda;
        }

        public Stock GetStockInfo(int itemId)
        {
            Query = "Select i.ReorderLevel,s.Quantity from StockIn s join Item i on i.Id = s.ItemId WHERE s.ItemId = '"+itemId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Stock stock = new Stock();
            if (Reader.Read())
            {
                stock.AvailableQuantity = Convert.ToInt32(Reader["Quantity"]);
                stock.ItemReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);
            }
            Reader.Close();
            Connection.Close();
            return stock;
        }

        public bool ItemExists(Stock stock)
        {
            Query = "SELECT * FROM StockIn WHERE ItemId = '" + stock.ItemId + "' AND CompanyId = '" + stock.CompanyId + "' ";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public int UpdateItem(Stock stock)
        {
            Query = "Update StockIn SET Quantity ='" + stock.Quantity + "' Where ItemId = '" + stock.ItemId + "' AND CompanyId = '" + stock.CompanyId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int SaveInStock(Stock stock)
        {
            Query = "INSERT INTO StockIn (CompanyId, ItemId, Quantity, Date) VALUES('" + stock.CompanyId + "','" + stock.ItemId + "','" + stock.Quantity + "','" + stock.Date + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int UpdateStockQuantity(Stock stock)
        {
            Query = "UPDATE s SET s.Quantity = '" + stock.Quantity + "' " +
                    "FROM StockIn AS s " +
                    "JOIN Item AS i ON s.Itemid = i.Id  " +
                    "Join Company c on s.CompanyId = c.Id " +
                    "WHERE i.Name = '" + stock.ItemName + "' and c.Name='" + stock.CompanyName + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        

        public int SellItem(Stock aStock)
        {
            Query = "INSERT INTO StockOut (CompanyId, ItemId, Quantity, Date, Sold) VALUES('" + aStock.CompanyId + "','" + aStock.ItemId + "','" + aStock.Quantity + "','" + aStock.Date + "', '" + aStock.Sold + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public Stock GetItemCompanyId(string itemName, string companyName)
        {
            Query =
                "Select c.Id as CompanyId, i.Id as ItemId, s.Quantity From  StockIn s " +
                "join Item i on i.Id = s.ItemId join Company c on c.Id = s.CompanyId " +
                "where c.Name = '"+companyName+"' And i.Name = '"+itemName+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
           
            Stock aStock = new Stock();
            if (Reader.Read())
            {
                aStock.ItemId = Convert.ToInt32(Reader["ItemId"]);
                aStock.CompanyId = Convert.ToInt32(Reader["CompanyId"]);
                aStock.AvailableQuantity = Convert.ToInt32(Reader["Quantity"]);
            }
            Reader.Close();
            Connection.Close();
            return aStock;
        }

        public int SaveDamagedItem(Stock aStock)
        {
            Query = "INSERT INTO StockOut (CompanyId, ItemId, Quantity, Date, Damaged) VALUES('" + aStock.CompanyId + "','" + aStock.ItemId + "','" + aStock.Quantity + "','" + aStock.Date + "', '" + aStock.Damaged + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int SaveLostItem(Stock aStock)
        {
            Query = "INSERT INTO StockOut (CompanyId, ItemId, Quantity, Date, Lost) VALUES('" + aStock.CompanyId + "','" + aStock.ItemId + "','" + aStock.Quantity + "','" + aStock.Date + "', '" + aStock.Lost + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Stock> GetAllItemInfoByCompanyId(int companyId)
        {
            Query = "Select i.Name ItemName, cm.Name CompanyName, c.Name CategoryName, IsNull(s.Quantity,0) AvQuantity, i.ReorderLevel ReorderLevel " +
                    "from Item i " +
                    "full join Company cm on i.CompanyId = cm.Id " +
                    "full Join Category c on i.CategoryId = c.Id " +
                    "full join StockIn s on i.id = s.ItemId " +
                    "Where i.CompanyId = '"+companyId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Stock> stockItems = new List<Stock>();

            while (Reader.Read())
            {
                Stock stock = new Stock();
                stock.ItemName = Reader["ItemName"].ToString();
                stock.CompanyName = Reader["CompanyName"].ToString();
                stock.CategoryName = Reader["CategoryName"].ToString();
                stock.AvailableQuantity = Convert.ToInt32(Reader["AvQuantity"]);
                stock.ItemReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                stockItems.Add(stock);
            }
            Reader.Close();
            Connection.Close();
            return stockItems;
        }

        public List<Stock> GetAllItemInfoByCategoryId(int categoryId)
        {
            Query = "Select i.Name ItemName, cm.Name CompanyName, c.Name CategoryName, IsNull(s.Quantity,0) AvQuantity, i.ReorderLevel ReorderLevel " +
                    "from Item i " +
                    "full join Company cm on i.CompanyId = cm.Id " +
                    "full Join Category c on i.CategoryId = c.Id " +
                    "full join StockIn s on i.id = s.ItemId " +
                    "Where i.CategoryId = '" + categoryId + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Stock> stockItems = new List<Stock>();

            while (Reader.Read())
            {
                Stock stock = new Stock();
                stock.ItemName = Reader["ItemName"].ToString();
                stock.CompanyName = Reader["CompanyName"].ToString();
                stock.CategoryName = Reader["CategoryName"].ToString();
                stock.AvailableQuantity = Convert.ToInt32(Reader["AvQuantity"]);
                stock.ItemReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                stockItems.Add(stock);
            }
            Reader.Close();
            Connection.Close();
            return stockItems;
        }

        public List<Stock> GetAllItemInfoByCompanyIdAndCategoryId(int categoryId, int companyId)
        {
            Query = "Select i.Name ItemName, cm.Name CompanyName, c.Name CategoryName, IsNull(s.Quantity,0) AvQuantity, i.ReorderLevel ReorderLevel " +
                    "from Item i " +
                    "full join Company cm on i.CompanyId = cm.Id " +
                    "full Join Category c on i.CategoryId = c.Id " +
                    "full join StockIn s on i.id = s.ItemId " +
                    "Where i.CategoryId = '" + categoryId + "'" +
                    "And i.CompanyId = '"+companyId+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Stock> stockItems = new List<Stock>();

            while (Reader.Read())
            {
                Stock stock = new Stock();
                stock.ItemName = Reader["ItemName"].ToString();
                stock.CompanyName = Reader["CompanyName"].ToString();
                stock.CategoryName = Reader["CategoryName"].ToString();
                stock.AvailableQuantity = Convert.ToInt32(Reader["AvQuantity"]);
                stock.ItemReorderLevel = Convert.ToInt32(Reader["ReorderLevel"]);

                stockItems.Add(stock);
            }
            Reader.Close();
            Connection.Close();
            return stockItems;
        }

        public List<Stock> GetAllSales(string fromDate, string toDate)
        {
            Query = "select i.Name Item, s.Quantity Quantity from StockOut s " +
                    "join Item i on i.Id = s.ItemId" +
                    " Where (s.Date between '"+fromDate+"' and '"+toDate+"') " +
                    "And Sold = 1";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Stock> stockItems = new List<Stock>();

            while (Reader.Read())
            {
                Stock stock = new Stock();
                stock.ItemName = Reader["Item"].ToString();
                stock.Quantity = Convert.ToInt32(Reader["Quantity"]);

                stockItems.Add(stock);
            }
            Reader.Close();
            Connection.Close();
            return stockItems;
        }
    }
}
