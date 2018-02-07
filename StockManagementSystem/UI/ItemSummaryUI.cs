using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;

namespace StockManagementSystem.UI
{
    public partial class ItemSummaryUI : Form
    {
        StockManager aStockManager = new StockManager();
        ItemManager aItemManager = new ItemManager();
        DataRow dr;
        public ItemSummaryUI(string user)
        {
            InitializeComponent();
            GetAllCompanyForComboBox();
            GetAllCategoryForComboBox();
            userNameLabel.Text = user;
        }
        int sl = 0;
        public void update()
        {
            this.summaryListView.Items.Clear();
            this.summaryListView.Update(); // In case there is databinding
            this.summaryListView.Refresh(); // Redraw items
        }
        private void searchButton_Click(object sender, EventArgs e)
        {

            update();
            if (companyComboBox.SelectedIndex == 0 && categoryComboBox.SelectedIndex == 0)
            {
                messageLabel.Text = "Please select company or Category";
            }
            else
            {
                if (companyComboBox.SelectedIndex > 0 && categoryComboBox.SelectedIndex == 0)
                {
                    Stock aStock = new Stock();
                    int companyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                    List<Stock> stockItems = aStockManager.GetAllItemInfoByCompanyId(companyId);

                    foreach (Stock stock in stockItems)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        sl++;
                        aListViewItem.Text = sl.ToString();
                        aListViewItem.SubItems.Add(stock.ItemName);
                        aListViewItem.SubItems.Add(stock.CompanyName);
                        aListViewItem.SubItems.Add(stock.CategoryName);
                        aListViewItem.SubItems.Add(stock.AvailableQuantity.ToString());
                        aListViewItem.SubItems.Add(stock.ItemReorderLevel.ToString());

                        summaryListView.Items.Add(aListViewItem);
                    }
                }
                else if (companyComboBox.SelectedIndex == 0 && categoryComboBox.SelectedIndex > 0)
                {
                    Stock aStock = new Stock();
                    int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue.ToString());
                    List<Stock> stockItems = aStockManager.GetAllItemInfoByCategoryId(categoryId);
                    int sl = 0;
                    foreach (Stock stock in stockItems)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        sl++;
                        aListViewItem.Text = sl.ToString();
                        aListViewItem.SubItems.Add(stock.ItemName);
                        aListViewItem.SubItems.Add(stock.CompanyName);
                        aListViewItem.SubItems.Add(stock.CategoryName);
                        aListViewItem.SubItems.Add(stock.AvailableQuantity.ToString());
                        aListViewItem.SubItems.Add(stock.ItemReorderLevel.ToString());

                        summaryListView.Items.Add(aListViewItem);
                    }
                }
                else if (companyComboBox.SelectedIndex > 0 && categoryComboBox.SelectedIndex > 0)
                {
                    Stock aStock = new Stock();
                    int categoryId = Convert.ToInt32(categoryComboBox.SelectedValue.ToString());
                    int companyId = Convert.ToInt32(companyComboBox.SelectedValue.ToString());
                    List<Stock> stockItems = aStockManager.GetAllItemInfoByCompanyIdAndCategoryId(categoryId, companyId);
                    int sl = 0;
                    foreach (Stock stock in stockItems)
                    {
                        ListViewItem aListViewItem = new ListViewItem();
                        sl++;
                        aListViewItem.Text = sl.ToString();
                        aListViewItem.SubItems.Add(stock.ItemName);
                        aListViewItem.SubItems.Add(stock.CompanyName);
                        aListViewItem.SubItems.Add(stock.CategoryName);
                        aListViewItem.SubItems.Add(stock.AvailableQuantity.ToString());
                        aListViewItem.SubItems.Add(stock.ItemReorderLevel.ToString());

                        summaryListView.Items.Add(aListViewItem);
                    }
                }
                pdfButton.Enabled = true;
            }
        }

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

        private void ItemSummaryUI_Load(object sender, EventArgs e)
        {
            if (summaryListView.Items.Count <= 0)
            {
                pdfButton.Enabled = false;
            }
        }

        private void pdfButton_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.A5, 40f, 10f, 20f, 0f);

            string fileName = generateRandomString(5) + ".pdf";

            PdfWriter.GetInstance(doc, new FileStream("G:/Downloads/" + fileName, FileMode.Create));
            doc.Open();

            
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("                            Stock Management system"));
            doc.Add(new Paragraph("                                  Stock item summary\n\n "));
            doc.Add(new Paragraph("                                                                Date: " + DateTime.Now.ToString("dd/MM/yyyy")+"\n\n\n"));
            if (companyComboBox.SelectedIndex > 0 && categoryComboBox.SelectedIndex > 0)
            {
                doc.Add(new Paragraph("Items of " + companyComboBox.Text + " Company and "+ categoryComboBox.Text+ " category\n"));
                
            }
            else if (companyComboBox.SelectedIndex > 0 && categoryComboBox.SelectedIndex == 0)
            {
                doc.Add(new Paragraph("Items of " + companyComboBox.Text + " company. \n\n"));
                
            }
            else if (companyComboBox.SelectedIndex == 0 && categoryComboBox.SelectedIndex > 0)
            {
                doc.Add(new Paragraph("Items of " + categoryComboBox.Text + " category. \n\n"));
            }
            
            doc.Add(new Paragraph("\n"));
            PdfPTable pdfTable = new PdfPTable(summaryListView.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 0.5f;

            //Adding Header row
            foreach (ColumnHeader column in summaryListView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (ListViewItem itemRow in summaryListView.Items)
            {
                int i = 0;
                for (i = 0; i < itemRow.SubItems.Count; i++)
                {
                    pdfTable.AddCell(itemRow.SubItems[i].Text);
                }
            }

            doc.Add(pdfTable);
            doc.Close();
        }

        public String generateRandomString(int length)
        {
            //Initiate objects & vars    
            Random random = new Random();
            String randomString = "";
            int randNumber;

            //Loop ‘length’ times to generate a random number or character
            for (int i = 0; i < length; i++)
            {
                if (random.Next(1, 3) == 1)
                    randNumber = random.Next(97, 123); //char {a-z}
                else
                    randNumber = random.Next(48, 58); //int {0-9}

                //append random char or digit to random string
                randomString = randomString + (char)randNumber;
            }
            //return the random string
            return randomString;
        }
    }
}
