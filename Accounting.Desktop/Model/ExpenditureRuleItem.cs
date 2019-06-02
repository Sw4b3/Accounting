using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Desktop.Model
{
    class ExpenditureRuleItem
    {
        public int ExpenditureRuleId { get; set; }

        public string ExpenditureDesc { get; set; }

        public override string ToString()
        {
            return ExpenditureDesc;
        }
    }
}
