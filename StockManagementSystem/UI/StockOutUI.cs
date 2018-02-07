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
    public partial class StockOutUI : Form
    {

        ItemManager anItemManager = new ItemManager();
        StockManager aStockManager = new StockManager();
        private DataRow dr;
        public StockOutUI(string user)
        {
            InitializeComponent();
            GetAllCompanyForComboBox();
            userNameLabel.Text = user;
            
        }
        int sl = 0;
        private void addButton_Click(object sender, EventArgs e)
        {

            Stock stock = new Stock();
            ListViewItem anItem = stockOutListView.FindItemWithText(itemComboBox.GetItemText(itemComboBox.SelectedItem));

            if (companyComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select a company";
            }
            else if (itemComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select an item";
            }
            else if (stockOutQuantityTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please enter quantity";
            }
            else if (Convert.ToInt32(stockOutQuantityTextBox.Text) < 0)
            {
                messageLabel.Text = "Quantity can not be negative";
            }else if (Convert.ToInt32(availableQuantityTextBox.Text) < (Convert.ToInt32(stockOutQuantityTextBox.Text)))
            {
                messageLabel.Text = "Available quantity is lower than stock out quantity";
            }
            else if (anItem != null)
            {
                
                stock.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);
                int quantity = Convert.ToInt32(anItem.SubItems[3].Text);
                anItem.SubItems[3].Text = (quantity + stock.Quantity).ToString();
                ClearAll();

                messageLabel.Text = "Quantity updated";
            } 
            else
            {
                stock.CompanyName = companyComboBox.GetItemText(companyComboBox.SelectedItem);
                stock.ItemName = itemComboBox.GetItemText(itemComboBox.SelectedItem);
                stock.ItemReorderLevel = Convert.ToInt32(reorderLevelTextBox.Text);
                stock.AvailableQuantity = Convert.ToInt32(availableQuantityTextBox.Text);
                stock.Quantity = Convert.ToInt32(stockOutQuantityTextBox.Text);

                ListViewItem item = new ListViewItem();
                sl++;
                item.Text = sl.ToString();
                item.SubItems.Add(stock.ItemName); 
                item.SubItems.Add(stock.CompanyName);
                item.SubItems.Add(stock.Quantity.ToString());

                stockOutListView.Items.Add(item);
                ClearAll();
                messageLabel.Text = "Item added to List";

                sellButton.Enabled = true;
                damagedButton.Enabled = true;
                lostButton.Enabled = true;
            } 
            
        }

        private void ClearAll()
        {
            companyComboBox.SelectedIndex = 0;
            itemComboBox.SelectedIndex = 0;
            reorderLevelTextBox.Text = String.Empty;
            availableQuantityTextBox.Text = String.Empty;
            stockOutQuantityTextBox.Text = String.Empty;
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
                int companyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString()) ;
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
            if (itemComboBox.SelectedIndex != 0)
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

        private void sellButton_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < stockOutListView.Items.Count; i++)
            {
                Stock aStock = new Stock();
                aStock.ItemName = stockOutListView.Items[i].SubItems[1].Text;
                aStock.CompanyName = stockOutListView.Items[i].SubItems[2].Text;
                aStock.Quantity = Convert.ToInt32(stockOutListView.Items[i].SubItems[3].Text);
                aStock.Date = DateTime.Now.ToString("yyyy-MM-dd");

               message = aStockManager.SellItem(aStock);
            }

            MessageBox.Show(message);
            this.Hide();
            StockOutUI stockOutUi = new StockOutUI(userNameLabel.Text);
            stockOutUi.Show();
        }

        private void StockOutUI_Load(object sender, EventArgs e)
        {
            if (stockOutListView.Items.Count <= 0)
            {
                sellButton.Enabled = false;
                damagedButton.Enabled = false;
                lostButton.Enabled = false;
            }
        }

        private void damagedButton_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < stockOutListView.Items.Count; i++)
            {
                Stock aStock = new Stock();
                aStock.ItemName = stockOutListView.Items[i].SubItems[1].Text;
                aStock.CompanyName = stockOutListView.Items[i].SubItems[2].Text;
                aStock.Quantity = Convert.ToInt32(stockOutListView.Items[i].SubItems[3].Text);
                aStock.Date = DateTime.Now.ToString("yyyy-MM-dd");

                message = aStockManager.SaveDamagedItem(aStock);
            }

            MessageBox.Show(message);
            this.Hide();
            StockOutUI stockOutUi = new StockOutUI(userNameLabel.Text);
            stockOutUi.Show();
        }

        private void lostButton_Click(object sender, EventArgs e)
        {
            string message = "";
            for (int i = 0; i < stockOutListView.Items.Count; i++)
            {
                Stock aStock = new Stock();
                aStock.ItemName = stockOutListView.Items[i].SubItems[1].Text;
                aStock.CompanyName = stockOutListView.Items[i].SubItems[2].Text;
                aStock.Quantity = Convert.ToInt32(stockOutListView.Items[i].SubItems[3].Text);
                aStock.Date = DateTime.Now.ToString("yyyy-MM-dd");

                message = aStockManager.SaveLostItem(aStock);
            }

            MessageBox.Show(message);
            this.Hide();
            StockOutUI stockOutUi = new StockOutUI(userNameLabel.Text);
            stockOutUi.Show();
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
