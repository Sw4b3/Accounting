using System;
using System.ComponentModel;

namespace Accounting.Models.Models
{
    public class ExpenditureViewModel
    {
        [DisplayName("Expenditure Id")]
        public Guid ExpenditureId { get; set; }

        [DisplayName("Transaction Id")]
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        [DisplayName("Timestamp")]
        public DateTime TransactionTimestamp { get; set; }

        [DisplayName("Type")]
        public string ExpenditureDesc { get; set; }
    }
}
