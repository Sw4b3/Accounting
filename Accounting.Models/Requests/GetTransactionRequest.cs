using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Requests
{
    public class GetTransactionRequest
    {
        public decimal Amount { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public int TransactionTypeId { get; set; }

        public int AccountTypeId { get; set; }

        public string Description { get; set; }

        public decimal Balance { get; set; }
    }
}
