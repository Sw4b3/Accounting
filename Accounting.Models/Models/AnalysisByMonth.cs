using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class AnalysisByMonth
    {
        public DateTime Date { get; set; }

        public Decimal Debit { get; set; }

        public Decimal Credit { get; set; }

        public Decimal Balance { get; set; }
    }
}
