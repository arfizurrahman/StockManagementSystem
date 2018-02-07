using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class StockManager
    {
        StockGateway aStockGateway = new StockGateway();
        public SqlDataAdapter GetItems(int companyId)
        {
            return aStockGateway.GetItems(companyId);
        }

        public Stock GetStockInfo(int itemId)
        {
            return aStockGateway.GetStockInfo(itemId);
        }

        public string SaveInStock(Stock stock)
        {
            if (aStockGateway.ItemExists(stock))
            {
                int rowAffected = aStockGateway.UpdateItem(stock);
                if (rowAffected > 0)
                {
                    return "Item quantity updated";
                }
                return "Couldn't update";
            }
            else
            {
                int rowAffected = aStockGateway.SaveInStock(stock);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                return "Save failed";
            }
        }

        public string SellItem(Stock aStock)
        {
            Stock stock = aStockGateway.GetItemCompanyId(aStock.ItemName,aStock.CompanyName);
            aStock.ItemId = stock.ItemId;
            aStock.CompanyId = stock.CompanyId;
            aStock.Sold = 1;
            int quantity = stock.AvailableQuantity - aStock.Quantity;

            Stock newStock = new Stock();
            newStock.ItemName = aStock.ItemName;
            newStock.CompanyName = aStock.CompanyName;
            newStock.Quantity = quantity;
            int r = aStockGateway.UpdateStockQuantity(newStock);
            int rowAffected = aStockGateway.SellItem(aStock);
            if (rowAffected > 0)
            {
                return "Item sold";
            }
            return "Operation failed";
        }

        public string SaveDamagedItem(Stock aStock)
        {
            Stock stock = aStockGateway.GetItemCompanyId(aStock.ItemName, aStock.CompanyName);
            aStock.ItemId = stock.ItemId;
            aStock.CompanyId = stock.CompanyId;
            aStock.Damaged = 1;
            int quantity = stock.AvailableQuantity - aStock.Quantity;

            Stock newStock = new Stock();
            newStock.ItemName = aStock.ItemName;
            newStock.CompanyName = aStock.CompanyName;
            newStock.Quantity = quantity;
            int r = aStockGateway.UpdateStockQuantity(newStock);
            int rowAffected = aStockGateway.SaveDamagedItem(aStock);
            if (rowAffected > 0)
            {
                return "Damaged Item info saved";
            }
            return "Operation failed";
        }

        public string SaveLostItem(Stock aStock)
        {
            Stock stock = aStockGateway.GetItemCompanyId(aStock.ItemName, aStock.CompanyName);
            aStock.ItemId = stock.ItemId;
            aStock.CompanyId = stock.CompanyId;
            aStock.Lost = 1;
            int quantity = stock.AvailableQuantity - aStock.Quantity;

            Stock newStock = new Stock();
            newStock.ItemName = aStock.ItemName;
            newStock.CompanyName = aStock.CompanyName;
            newStock.Quantity = quantity;
            int r = aStockGateway.UpdateStockQuantity(newStock);
            int rowAffected = aStockGateway.SaveLostItem(aStock);
            if (rowAffected > 0)
            {
                return "Lost Item info saved";
            }
            return "Operation failed";
        }

        public List<Stock> GetAllItemInfoByCompanyId(int companyId)
        {
            return aStockGateway.GetAllItemInfoByCompanyId(companyId);
        }

        public List<Stock> GetAllItemInfoByCategoryId(int categoryId)
        {
            return aStockGateway.GetAllItemInfoByCategoryId(categoryId);
        }

        public List<Stock> GetAllItemInfoByCompanyIdAndCategoryId(int categoryId, int companyId)
        {
            return aStockGateway.GetAllItemInfoByCompanyIdAndCategoryId(categoryId, companyId);
        }

        public List<Stock> GetAllSales(string fromDate, string toDate)
        {
            return aStockGateway.GetAllSales(fromDate, toDate);
        }
    }
}
