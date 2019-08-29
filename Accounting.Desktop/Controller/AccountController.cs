using Accounting.Desktop.Model;
using Accounting.Domain.Services.Service;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
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

        public string GetAccountBalance(int accountId)
        {
            return _accountService.GetAccount().FirstOrDefault(x =>  x.AccountId== accountId).CurrentBalance.ToString();
        }

        public string GetAccountAvaliableBalance(int accountId)
        {
            return _accountService.GetAccount().FirstOrDefault(x => x.AccountId == accountId).AvailableBalance.ToString();
        }

        public void GetAccount(DataGridView dataGrid)
        {
            dataGrid.DataSource = _accountService.GetAccount().Select(x => new { x.AccountId, x.AccountNo , x.AccountType, x.Status, x.CurrentBalance, x.AvailableBalance }).ToList();
        }

        public Account GetAccount(GetAccountRequest getAccountRequest)
        {
            return _accountService.GetAccount(getAccountRequest);
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

        public void SaveAccount(SaveAccountRequest account)
        {
            _accountService.SaveAccount(account);
        }

        public void UpdateAccount(UpdateAccountRequest request)
        {
            _accountService.UpdateAccount(request);
        }

        public UpdateAccountRequest GetAccountDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new UpdateAccountRequest
                {
                    AccountId = int.Parse(selectedRow.Cells[0].Value.ToString()),
                };
            }
            return null;
        }

    }
}
