using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Common.Interfaces
{
    public interface IPageableCollection<out TResult>
    {
        public IEnumerable<TResult> Results { get; }
        public long Total { get; }
    }
}
