using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class ExpenditureRule
    {
        public int ExpenditureRuleId { get; set; }

        public String ExpenditureDesc { get; set; }

        public Decimal ExpenditureLimit { get; set; }
    }
}
