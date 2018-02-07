using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.Manager;
using StockManagementSystem.Model;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Web.UI.WebControls;
using iTextSharp.text.pdf.events;

namespace StockManagementSystem.UI
{
    public partial class SalesBetweenDatesUI : Form
    {
        StockManager aStockManager = new StockManager();
        public SalesBetweenDatesUI(string user)
        {
            InitializeComponent();
            userNameLabel.Text = user;
            
        }
        public void update()
        {
            this.salesListView.Items.Clear();
            this.salesListView.Update(); // In case there is databinding
            this.salesListView.Refresh(); // Redraw items
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            pdfButton.Enabled = true;
            update();

            string fromDateString = fromDateTimePicker1.Text;
            string format = "mm/dd/yyyy";
            DateTime fromDateTime = DateTime.ParseExact(fromDateString, format, CultureInfo.InvariantCulture);
            string fromDate = fromDateTime.ToString("yyyy-mm-dd");
            
            string toDateString = toDateTimePicker2.Text;
            DateTime toDateTime = DateTime.ParseExact(toDateString, format, CultureInfo.InvariantCulture);
            string toDate = toDateTime.ToString("yyyy-mm-dd");
            int sl = 0;
            Stock aStock = new Stock();
            List<Stock> stockItems = aStockManager.GetAllSales(fromDate,toDate);

            foreach (Stock stock in stockItems)
            {
                ListViewItem aListViewItem = new ListViewItem();
                sl++;
                aListViewItem.Text = sl.ToString();
                aListViewItem.SubItems.Add(stock.ItemName);
                aListViewItem.SubItems.Add(stock.Quantity.ToString());

                salesListView.Items.Add(aListViewItem);
            }

            pdfButton.Enabled = true;

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

        private void pdfButton_Click(object sender, EventArgs e)
        {
            
            Document doc = new Document(iTextSharp.text.PageSize.A5,40f,10f,20f,0f);

            string fileName = generateRandomString(5) + ".pdf"; 

            PdfWriter.GetInstance(doc,new FileStream("G:/Downloads/"+fileName, FileMode.Create));
            doc.Open();
           
            //doc.Add(new Phrase(Element.ALIGN_RIGHT, new Chunk("Stock Management system".ToString(),
            //    FontFactory.GetFont(FontFactory.HELVETICA, 13, 4))));
            doc.Add(new Paragraph("\n"));
            doc.Add(new Paragraph("                            Stock Management system"));
            doc.Add(new Paragraph("                                          Sales report\n\n "));
            doc.Add(new Paragraph("From: " + fromDateTimePicker1.Text+"                                         Date: "+DateTime.Now.ToString("dd/MM/yyyy")));
            doc.Add(new Paragraph("To: " + toDateTimePicker2.Text + "\n\n"));
            doc.Add(new Paragraph("Total sale:"));
            doc.Add(new Paragraph("\n"));
            PdfPTable pdfTable = new PdfPTable(salesListView.Columns.Count);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 70;
            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfTable.DefaultCell.BorderWidth = 0.5f;

            //Adding Header row
            foreach (ColumnHeader column in salesListView.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.Text));
                pdfTable.AddCell(cell);
            }

            //Adding DataRow
            foreach (ListViewItem itemRow in salesListView.Items)
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

        private void SalesBetweenDatesUI_Load(object sender, EventArgs e)
        {
            if (salesListView.Items.Count <= 0)
            {
                pdfButton.Enabled = false;
            }
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
