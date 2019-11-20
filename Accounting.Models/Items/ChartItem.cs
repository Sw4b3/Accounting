using System.Collections.Generic;

namespace Accounting.Models.Models
{
    public class ChartItem
    {
        public IList<string> Headers { get; set; }

        public IList<decimal> Data { get; set; }

    }
}
