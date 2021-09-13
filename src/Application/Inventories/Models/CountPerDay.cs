using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Inventories.Models
{
    public class CountPerDay
    {
        public DateTime Day { get; set; }
        public long Count { get; set; }
    }
}
