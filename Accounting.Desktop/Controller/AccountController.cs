using Accounting.Desktop.Model;
using Accounting.Models.Requests;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.Controller
{
    class AccountController
    {
        public AccountRepository _accountRepository;

        public AccountController()
        {
            _accountRepository = new AccountRepository();
        }

        public void GetAccount(DataGridView dataGrid) {
            dataGrid.DataSource= _accountRepository.GetAccountRequest().Select(x => new {   x.AccountId,  x.AccountType }).ToList();
        }

        public void GetAccountComboBox(ComboBox comboBox)
        {
            var expenses = _accountRepository.GetAccountRequest().Select(x => new AccountItem { AccountId = x.AccountId, AccountType = x.AccountType }).ToList();
            comboBox.DataSource = expenses.ToList();
        }

        public int GetAccountId(ComboBox comboBox)
        {
            return ((AccountItem)comboBox.SelectedItem).AccountId;
        }

        public void SaveAccount(AccountRequest account)
        {
            _accountRepository.SaveAccountRequest(account);
        }
    }
}
