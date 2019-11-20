namespace Accounting.Models.Models
{
    public class ExpenditureOverview
    {
        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureTotal { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public bool ShouldDisplay { get; set; }

    }
}
