using System;

namespace Accounting.Models.Requests
{
    public class UpdateTransactionRequest
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }
    }
}
