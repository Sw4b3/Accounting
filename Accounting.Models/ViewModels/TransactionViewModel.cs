using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.ViewModels
{
    public class TransactionViewModel
    {
        public Guid TransactionId { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime TransactionTimestamp { get; set; }

        public string TransactionType { get; set; }

        public string Balance { get; set; }

    }
}
