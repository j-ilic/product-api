using Products.Application.Common.Mappings;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Models
{
    public class InventoriedItemModel : IMapFrom<InventoryItem>
    {
        public string CompanyPrefix { get; set; }
        public string ItemReference { get; set; }
        public string SerialNumber { get; set; }
        public string TagUri { get; set; }
        public string HexTag { get; set; }
    }
}
