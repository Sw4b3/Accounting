using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
   public class Expenditure
    {
        public Guid ExpenditureId { get; set; }

        public Guid TransactionId { get; set; }

        public int ExpenditureTypeId { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public DateTime TransactionTimestamp { get; set; }
    }
}
