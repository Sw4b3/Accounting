namespace Accounting.Models.Requests
{
    public class SaveExpenditureTypeRequest
    {
        public string ExpenditureDesc { get; set; }

        public decimal ExpenditureLimit { get; set; }

        public int ExpenditureTypeId { get; set; }
    }
}
