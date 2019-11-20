using System;

namespace Accounting.Models.Requests
{
    public class DeleteTransactionRequest
    {
        public Guid TransactionId { get; set; }
    }
}
