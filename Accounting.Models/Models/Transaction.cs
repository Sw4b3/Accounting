using System;

namespace Accounting.Models.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Balance { get; set; }

        public string Description { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public int TransactionTypeId { get; set; }

        public string TransactionType { get; set; }

        public int AccountTypeId { get; set; }

        public string AccountType { get; set; }

        public Guid FileId { get; set; }
    }
}
