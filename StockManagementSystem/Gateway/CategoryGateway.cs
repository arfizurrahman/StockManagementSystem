using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;

namespace StockManagementSystem.Gateway
{
    class CategoryGateway : Gateway
    {
        public int SaveCategory(Category category)
        {
            Query = "INSERT INTO Category (Name) VALUES('" + category.Name + "')";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public bool IsCategoryExistes(string categoryName)
        {
            Query = "SELECT * FROM Category WHERE Name = '" + categoryName + "'";
            Command = new SqlCommand(Query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            bool isExist = Reader.HasRows;
            Reader.Close();
            Connection.Close();
            return isExist;
        }

        public List<Category> GetAllCategories()
        {
            Query = "SELECT * FROM Category";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Category> categories = new List<Category>();
            
            while (Reader.Read())
            {
                Category category = new Category();
                category.Id = Convert.ToInt32(Reader["Id"]);
                category.Name = Reader["Name"].ToString();
                
                categories.Add(category);
            }
            Reader.Close();
            Connection.Close();
            return categories;
        }

        public int UpdateCategory(Category category)
        {
            Query = "Update Category SET Name ='" + category.Name + "' Where Id = '"+category.Id+"'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int GetCategoryId(Category category)
        {
            Query = "SELECT * FROM Category WHERE Name='" + category.Name + "'";
            Command = new SqlCommand(Query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();

            if (Reader.Read())
            {
                Category aCategory = new Category();
                category.Id = Convert.ToInt32(Reader["Id"]);
            }
            Reader.Close();
            Connection.Close();
            return category.Id;
        }

        
    }
}
