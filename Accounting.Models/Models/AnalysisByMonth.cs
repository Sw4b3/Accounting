using System;

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
