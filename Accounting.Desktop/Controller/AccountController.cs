using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Models.Requests;

using System.Linq;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    class AccountController
    {
        private readonly AccountService _accountService;

        public AccountController()
        {
            _accountService = new AccountService();
        }

        public void GetAccount(DataGridView dataGrid) {
            dataGrid.DataSource= _accountService.GetAccount().Select(x => new {   x.AccountId,  x.AccountType }).ToList();
        }

        public void GetAccountComboBox(ComboBox comboBox)
        {
            var expenses = _accountService.GetAccount().Select(x => new AccountItem { AccountId = x.AccountId, AccountType = x.AccountType }).ToList();
            comboBox.DataSource = expenses.ToList();
        }

        public int GetAccountId(ComboBox comboBox)
        {
            return ((AccountItem)comboBox.SelectedItem).AccountId;
        }

        public void SaveAccount(AccountRequest account)
        {
            _accountService.SaveAccount(account);
        }
    }
}
