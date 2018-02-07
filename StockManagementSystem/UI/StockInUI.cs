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
    public partial class StockInUI : Form
    {
        ItemManager anItemManager = new ItemManager();
        StockManager aStockManager = new StockManager();
        private DataRow dr;
        public StockInUI(string user)
        {
            InitializeComponent();
            GetAllCompanyForComboBox();
            userNameLabel.Text = user;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Stock stock = new Stock();
            if (companyComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select a company";
            }
            else if (itemComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select an item";
            }
            else if (stockInQuantityTexBox.Text == String.Empty)
            {
                messageLabel.Text = "Please enter quantity";
            }
            else if (Convert.ToInt32(stockInQuantityTexBox.Text) < 0 )
            {
                messageLabel.Text = "Quantity can not be negative";
            }
            else
            {
                stock.CompanyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                stock.ItemId = Convert.ToInt32(itemComboBox.SelectedValue.ToString());
                stock.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                int quantity = stock.AvailableQuantity + Convert.ToInt32(stockInQuantityTexBox.Text);
                stock.Quantity = quantity;
                stock.Date = DateTime.Now.ToString("yyyy-MM-dd");
                
                string message = aStockManager.SaveInStock(stock);
                messageLabel.Text = message;
                ClearAll();
            }
            
        }

        private void ClearAll()
        {
            companyComboBox.SelectedIndex = 0;
            itemComboBox.SelectedIndex = 0;
            reorderLevelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;
            stockInQuantityTexBox.Text =String.Empty;
        }
        private void GetAllCompanyForComboBox()
        {

            SqlDataAdapter sda = anItemManager.GetCompanies();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Company--" };
            dt.Rows.InsertAt(dr, 0);
            companyComboBox.ValueMember = "Id";
            companyComboBox.DisplayMember = "Name";
            companyComboBox.DataSource = dt;
        }

        private void companyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(companyComboBox.SelectedValue.ToString()) != 0)
            {
                int companyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                GetAllItems(companyId);
            }
        }

        private void GetAllItems(int companyId)
        {
            SqlDataAdapter sda = aStockManager.GetItems(companyId);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { 0, "--Select Item--" };
            dt.Rows.InsertAt(dr, 0);
            itemComboBox.ValueMember = "Id";
            itemComboBox.DisplayMember = "Name";
            itemComboBox.DataSource = dt;
        }

        private void itemComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(itemComboBox.SelectedValue.ToString()) != 0)
            {
                int itemId = Convert.ToInt32(itemComboBox.SelectedValue.ToString()); ;
                GetStockInfo(itemId);
            }
        }

        private void GetStockInfo(int itemId)
        {
            Stock stock = aStockManager.GetStockInfo(itemId);
            reorderLevelTextBox.Text = stock.ItemReorderLevel.ToString();
            availableQuantityTextBox.Text = stock.AvailableQuantity.ToString();

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
