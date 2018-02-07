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
    class ItemManager
    {
        ItemGateway aItemGateway = new ItemGateway();
        CategoryGateway aCategoryGateway = new CategoryGateway();

        public SqlDataAdapter GetCategories()
        {
            return aItemGateway.GetCategories();
        }
        public SqlDataAdapter GetCompanies()
        {
            return aItemGateway.GetCompanies();
        }

        public string SaveItem(Item aItem)
        {
            if (aItemGateway.IsItemExistes(aItem.Name))
            {
                return "Item already exists";
            }
            else
            {
                int rowAffected = aItemGateway.SaveItem(aItem);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                return "Save failed";
            }
        }
    }
}
