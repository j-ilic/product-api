using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public string CompanyPrefix { get; set; }
        public string CompanyName { get; set; }
        public string ItemReference { get; set; }
        public string ProductName { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
