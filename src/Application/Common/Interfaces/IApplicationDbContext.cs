using Microsoft.EntityFrameworkCore;
using Products.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Products.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Inventory> Inventories { get; set; }
        DbSet<InventoryItem> InventoryItems { get; set; }
        DbSet<Product> Products { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
