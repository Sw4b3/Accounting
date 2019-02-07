using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; }

        public int TransactionTypeId { get; set; }

        public int AcounTypetId { get; set; }

    }
}
