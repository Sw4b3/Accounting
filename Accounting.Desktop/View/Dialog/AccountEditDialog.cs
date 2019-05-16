using Accounting.Desktop.Common;
using Accounting.Desktop.Controller;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.View
{
    public partial class AccountEditDialog : Form
    {
        private AccountController _accountController;
        private MainApplication _mainForm;
        private UpdateAccountRequest _accountRequest;

        public AccountEditDialog(UpdateAccountRequest accountRequest,  MainApplication mainForm)
        {
            InitializeComponent();
            _accountController = new AccountController();
            _mainForm = mainForm;
            _accountRequest = accountRequest;
        }

        public void UpdateAccount() {
            if (Validator.IsNumber(textBox3.Text))
            {
                _accountController.UpdateAccount(new UpdateAccountRequest
                {
                    AccountId = _accountRequest.AccountId,
                    AvailableBalance = decimal.Parse(textBox3.Text),
                });
                _mainForm.PopulateAccountTable();
                this.Dispose();
                MessageBox.Show("Available Balance Updated", "", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Please enter valid Amount", "Updated", MessageBoxButtons.OK);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            UpdateAccount();
        }
    }
}
