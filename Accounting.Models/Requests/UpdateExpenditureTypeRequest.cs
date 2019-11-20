namespace Accounting.Models.Models
{
    public class UpdateExpenditureRuleRequest
    {
        public int ExpenditureRuleId { get; set; }

        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public bool ShouldDisplay { get; set; }
    }
}
