using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class UpdateTransactionRequest
    {
        public Guid TransactionId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string TransactionStatus { get; set; }
    }
}
