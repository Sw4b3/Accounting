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

        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public bool ShouldDisplay { get; set; }
    }
}
