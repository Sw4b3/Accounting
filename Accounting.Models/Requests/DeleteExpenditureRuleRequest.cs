using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Models.Models
{
    public class DeleteExpenditureRuleRequest
    {
        public int ExpenditureRuleId { get; set; }

        public bool IsArchived { get; set; }

        public DateTime ArchivedDate { get; set; }
    }
}
