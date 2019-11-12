using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class BarChartItem
    {
        public IList<string> Headers { get; set; }

        public IList<decimal> Data { get; set; }

    }
}
