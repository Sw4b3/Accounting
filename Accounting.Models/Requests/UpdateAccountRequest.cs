namespace Accounting.Models.Requests
{
    public class UpdateAccountRequest
    {
        public int AccountId { get; set; }

        public decimal AvailableBalance { get; set; }

    }
}
