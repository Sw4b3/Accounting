using System;

namespace Accounting.Models.Models
{
    public class AnalysisByDay
    {
        public DateTime TransactionTimestamp { get; set; }

        public Decimal Amount { get; set; }
    }
}
