using System;

namespace Accounting.Models.Requests
{
    public class SaveTransactionRequest
    {
        public decimal Amount { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public int TransactionTypeId { get; set; }

        public int AccountTypeId { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }
    }
}
