using System;

namespace Accounting.Models.Models
{
    public class UpdateExpenditureRequest
    {
        public Guid ExpenditureId { get; set; }

        public int ExpenditureRuleId { get; set; }

    }
}
