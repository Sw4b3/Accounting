using System;

namespace Accounting.Models.ViewModels
{
    public class TransferViewModel
    {
        public Guid TransactionId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public string TransactionType { get; set; }

        public string AccountType { get; set; }

    }
}
