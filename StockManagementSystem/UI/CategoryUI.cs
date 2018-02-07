using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class CategoryUI : Form
    {
        CategoryManager aCategoryManager = new CategoryManager();
        public CategoryUI(string userName)
        {
            InitializeComponent();
            userNameLabel.Text = userName;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
           Category aCategory = new Category();
            if (nameTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please enter a category.";
            }
            else
            {
                aCategory.Name = nameTextBox.Text;

                string message = aCategoryManager.SaveCategory(aCategory);
                PopulateCategoryListView();
                nameTextBox.Text = String.Empty;
                messageLabel.Text = message;
            }
            
        }

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            PopulateCategoryListView();
        }
        private void PopulateCategoryListView()
        {
            categoryListView.Items.Clear();
            List<Category> categories = aCategoryManager.GetAllCategories();
            int sl = 0;
            foreach (Category category in categories)
            {
                sl++;
                ListViewItem item = new ListViewItem();
                
                item.Text = sl.ToString();
                item.SubItems.Add(category.Name);
                categoryListView.Items.Add(item);
            }
        }

       

        private void categoryListView_ItemActivate(object sender, EventArgs e)
        {

            
            Category category = new Category();
            //category.Name = categoryListView.SelectedItems[0].SubItems[0].ToString();

            if (categoryListView.SelectedItems.Count > 0)
            {
                ListViewItem items = categoryListView.SelectedItems[0];
                category.Name = items.SubItems[1].Text;
            }
            int id = aCategoryManager.GetCategoryId(category);
            UpdateCategoryUI aUpdateCategoryUi = new UpdateCategoryUI(category.Name, id,userNameLabel.Text);
            aUpdateCategoryUi.Show();
            this.Hide();
           
            
        }

        

        private void setupCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            CategoryUI aCategoryUi = new CategoryUI(userNameLabel.Text);
            aCategoryUi.Show();
        }

        private void setupCompanyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetUpCompanyUI aCompanyUi = new SetUpCompanyUI(userNameLabel.Text);
            aCompanyUi.Show();
        }

        private void setupItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SetupItemUI setupItemUi = new SetupItemUI(userNameLabel.Text);
            setupItemUi.Show();
        }

        private void stockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockInUI aStockInUi = new StockInUI(userNameLabel.Text);
            aStockInUi.Show();
        }

        private void stockOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            StockOutUI stockOutUi = new StockOutUI(userNameLabel.Text);
            stockOutUi.Show();
        }

        private void itemSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemSummaryUI summaryUi = new ItemSummaryUI(userNameLabel.Text);
            summaryUi.Show();
        }

        private void viewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesBetweenDatesUI salesBetweenDatesUi = new SalesBetweenDatesUI(userNameLabel.Text);
            salesBetweenDatesUi.Show();
        }

        
    }
}
