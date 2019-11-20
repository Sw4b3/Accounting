using System;

namespace Accounting.Models.Models
{
    public class Expenditure
    {
        public Guid ExpenditureId { get; set; }

        public Guid TransactionId { get; set; }

        public int ExpenditureRuleId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public string ExpenditureDesc { get; set; }
    }
}
