namespace Accounting.Desktop.Model
{
    public class AccountItem
    {
        public int AccountId { get; set; }

        public string AccountType { get; set; }

        public override string ToString()
        {
            return AccountType;
        }
    }
}
