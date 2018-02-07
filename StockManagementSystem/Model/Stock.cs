using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
    class Stock
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public int AvailableQuantity { get; set; }
        public int ItemReorderLevel { get; set; }
        public int Sold { get; set; }
        public int Damaged { get; set; }
        public int Lost { get; set; }
        public string Date { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
