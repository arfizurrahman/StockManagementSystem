using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Gateway;
using StockManagementSystem.Model;

namespace StockManagementSystem.Manager
{
    class CategoryManager
    {
        private CategoryGateway aCategoryGateway = new CategoryGateway();

        public string SaveCategory(Category category)
        {
            if (aCategoryGateway.IsCategoryExistes(category.Name))
            {
                return "Category already exists";
            }
            else
            {
                int rowAffected = aCategoryGateway.SaveCategory(category);
                if (rowAffected > 0)
                {
                    return "Saved successfully";
                }
                return "Save failed";
            }
           
        }

        public List<Category> GetAllCategories()
        {
            return aCategoryGateway.GetAllCategories();
        }

        public string UpdateCategory(Category category)
        {
            if (aCategoryGateway.IsCategoryExistes(category.Name))
            {
                return "Category already exists";
            }
            else
            {
                
                int rowAffected = aCategoryGateway.UpdateCategory(category);
                if (rowAffected > 0)
                {
                    return "Updates successfully";
                }
                return "Update failed";
            }

        }

        public int GetCategoryId(Category category)
        {
            category.Id = aCategoryGateway.GetCategoryId(category);
            return category.Id;
        }


    }
}
