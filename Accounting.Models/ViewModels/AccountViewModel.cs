namespace Accounting.Models.Models
{
    public class AccountViewModel
    {
        public string AccountNo { get; set; }

        public int AccountId { get; set; }

        public string AccountType { get; set; }

        public decimal CurrentBalance { get; set; }

        public decimal AvailableBalance { get; set; }

        public string Status { get; set; }
    }
}
