using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Infrastructure.Persistence.SeedData
{
    public class ProductData
    {
        [Name("company_prefix")]
        public string CompanyPrefix { get; set; }
        [Name("company_name")]
        public string CompanyName { get; set; }
        [Name("item_reference")]
        public string ItemReference { get; set; }
        [Name("item_name")]
        public string ProductName { get; set; }
    }
}
