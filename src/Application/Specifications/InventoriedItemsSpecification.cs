using LinqKit;
using Products.Application.Common.Interfaces;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Specifications
{
    public class InventoriedItemsSpecification : ISpecification<InventoryItem>
    {
        public InventoriedItemsSpecification(string companyPrefix, string itemReference = default, string inventoryId = default)
        {
            CompanyPrefix = companyPrefix;
            ItemReference = itemReference;
            InventoryId = inventoryId;
        }

        public string CompanyPrefix { get; }
        public string ItemReference { get; }
        public string InventoryId { get; }

        public Expression<Func<InventoryItem, bool>> Predicate
        {
            get
            {
                Expression<Func<InventoryItem, bool>> predicate = t => true;

                if (!string.IsNullOrWhiteSpace(CompanyPrefix))
                {
                    predicate = predicate.And(t => t.CompanyPrefix == CompanyPrefix);
                }

                if (!string.IsNullOrWhiteSpace(ItemReference))
                {
                    predicate = predicate.And(t => t.ItemReference == ItemReference);
                }

                if (!string.IsNullOrWhiteSpace(InventoryId))
                {
                    predicate = predicate.And(t => t.InventoryId == InventoryId);
                }

                return predicate.Expand();
            }
        }
    }
}
