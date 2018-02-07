using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class UpdateCategoryUI : Form
    {
        
        CategoryManager aCategoryManager = new CategoryManager();
        private int id;
        public UpdateCategoryUI(string category, int id,string user)
        {
            InitializeComponent();
            categoryTextBox.Text = category;
            this.id = id;
            userNameLabel.Text = user;
        }
        

        private void updateCategoryButton_Click(object sender, EventArgs e)
        {

            Category category = new Category();
            
            if (categoryTextBox.Text == String.Empty)
            {
                MessageBox.Show("Please enter a category");
            }
            else
            {
                category.Name = categoryTextBox.Text;
                category.Id = id;
                string message = aCategoryManager.UpdateCategory(category);
                MessageBox.Show(message);
                this.Hide();
                CategoryUI aCategoryUi = new CategoryUI(userNameLabel.Text);
                aCategoryUi.Show();
            }
           
            
        }
      
    }
}
