using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class Inventory
    {
        public Inventory()
        {
            InventoryItems = new List<InventoryItem>();
        }

        public string InventoryId { get; set; }
        public string InventoryLocation { get; set; }
        public DateTime InventoryDate { get; set; }
        public virtual ICollection<InventoryItem> InventoryItems { get; set; }
    }
}
