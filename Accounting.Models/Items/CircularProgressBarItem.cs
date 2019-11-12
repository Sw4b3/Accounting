using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class CircularProgressBarItem
    {
        public decimal ExpenditureLimit { get; set; }

        public IList<decimal> Data { get; set; }

    }
}
