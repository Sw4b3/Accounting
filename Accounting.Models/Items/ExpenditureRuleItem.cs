namespace Accounting.Desktop.Model
{
    public class ExpenditureRuleItem
    {
        public int ExpenditureRuleId { get; set; }

        public string ExpenditureDesc { get; set; }

        public override string ToString()
        {
            return ExpenditureDesc;
        }
    }
}
