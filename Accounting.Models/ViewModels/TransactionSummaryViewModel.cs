using System;

namespace Accounting.Models.ViewModels
{
    public class TransactionSummaryViewModel
    {
        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionTimestamp { get; set; }

    }
}
