using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class SetUpCompanyUI : Form
    {
        CompanyManager aCompanyManager = new CompanyManager();
        public SetUpCompanyUI(string user)
        {
            InitializeComponent();
            userNameLabel.Text = user;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Company company = new Company();
            if (nameTextBox.Text == String.Empty)
            {
                messageLabel.Text = "Please enter the company name";
            }
            else
            {
                company.Name = nameTextBox.Text;

                string message = aCompanyManager.SaveCompany(company);
                PopulateCompanyListView();
                nameTextBox.Text = String.Empty;
                messageLabel.Text = message;
            }
            
        }
        private void PopulateCompanyListView()
        {
            companyListView.Items.Clear();
            List<Company> companies = aCompanyManager.GetAllCompanies();
            int sl = 0;
            foreach (Company category in companies)
            {
                sl++;
                ListViewItem item = new ListViewItem();

                item.Text = sl.ToString();
                item.SubItems.Add(category.Name);
                companyListView.Items.Add(item);
            }
        }

        private void SetUpCompanyUI_Load(object sender, EventArgs e)
        {
            PopulateCompanyListView();
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
