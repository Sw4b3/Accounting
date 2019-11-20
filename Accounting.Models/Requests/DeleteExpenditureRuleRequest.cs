using System;

namespace Accounting.Models.Models
{
    public class DeleteExpenditureRuleRequest
    {
        public int ExpenditureRuleId { get; set; }

        public bool IsArchived { get; set; }

        public DateTime ArchivedDate { get; set; }
    }
}
