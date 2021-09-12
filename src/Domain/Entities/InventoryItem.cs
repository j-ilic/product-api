using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class InventoryItem
    {
        public InventoryItem()
        {

        }

        public string InventoryId { get; set; }
        public string CompanyPrefix { get; set; }
        public string ItemReference { get; set; }
        public string SerialNumber { get; set; }
        public byte Filter { get; set; }
        public string TagUri { get; set; }
        public string HexTag { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
    }
}
