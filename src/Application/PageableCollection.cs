using Products.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application
{
    public class PageableCollection<TResult> : IPageableCollection<TResult>
    {
        public PageableCollection(IEnumerable<TResult> results, long total)
        {
            Results = results;
            Total = total;
        }

        public IEnumerable<TResult> Results { get; }
        public long Total { get; }
    }
}
