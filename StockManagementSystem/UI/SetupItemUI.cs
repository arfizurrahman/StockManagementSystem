using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class SetupItemUI : Form
    {
        ItemManager aItemManager = new ItemManager();
        DataRow dr;  
        public SetupItemUI(string user)
        {
            InitializeComponent();
            GetAllCategoryForComboBox();
            GetAllCompanyForComboBox();
            reorderTextBox.Text = 0.ToString();
            userNameLabel.Text = user;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Item aItem = new Item();
            if (categoryComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select category";
            }
            else if (companyComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select company";
            }
            else if(itemTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please enter item name";
            }
            else if (Convert.ToInt32(reorderTextBox.Text) < 0)
            {
                messageLabel.Text = "Reorder level cannot be negative";
            }
            else if (Convert.ToInt32(reorderTextBox.Text) < 0)
            {
                messageLabel.Text = "Reorder level cannot be negative";
            }
            else
            {
                aItem.CategoryId = Convert.ToInt32(categoryComboBox.SelectedValue.ToString());
                aItem.CompanyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                aItem.Name = itemTextBox.Text;
                aItem.ReorderLevel = Convert.ToInt32(reorderTextBox.Text);
                string message = aItemManager.SaveItem(aItem);
                messageLabel.Text = message;
            }
            
            ClearAll();
        }
        //This method gets all categories for combo box
        private void GetAllCategoryForComboBox()
        {

            SqlDataAdapter sda = aItemManager.GetCategories();
            DataTable dt = new DataTable();  
            sda.Fill(dt);  
            dr = dt.NewRow();  
            dr.ItemArray = new object[] { 0, "--Select Category--" };  
            dt.Rows.InsertAt(dr, 0);  
            categoryComboBox.ValueMember = "Id";  
            categoryComboBox.DisplayMember = "Name";  
            categoryComboBox.DataSource = dt;
        }
        //This method gets all company for comboBox
        private void GetAllCompanyForComboBox()
        {

            SqlDataAdapter sda = aItemManager.GetCompanies();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Company--" };
            dt.Rows.InsertAt(dr, 0);
            companyComboBox.ValueMember = "Id";
            companyComboBox.DisplayMember = "Name";
            companyComboBox.DataSource = dt;
        }

        private void ClearAll()
        {
            categoryComboBox.SelectedIndex = 0;
            companyComboBox.SelectedIndex = 0;
            itemTextBox.Text = String.Empty;
            reorderTextBox.Text = 0.ToString();
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

        private void vIewSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesBetweenDatesUI salesBetweenDatesUi = new SalesBetweenDatesUI(userNameLabel.Text);
            salesBetweenDatesUi.Show();
        }
    }
}
