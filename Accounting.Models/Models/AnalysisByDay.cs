using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class AnalysisByDay
    {
        public DateTime TransactionTimestamp { get; set; }

        public Decimal Amount { get; set; }
    }
}
