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
    public partial class AccountDialog : Form
    {
        private AccountController _accountController;
        private MainApplication _mainForm;

        public AccountDialog(MainApplication mainForm)
        {
            InitializeComponent();
            _accountController = new AccountController();
            _mainForm = mainForm;
        }

        public void SaveAccount() {
            if (Validator.IsString(nameTextBox.Text))
            {
                _accountController.SaveAccount(new SaveAccountRequest
                {
                    AccountType = nameTextBox.Text,
                    AccountNo = numberTextBox.Text,
                });
                _mainForm.PopulateAccountTable();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter valid Account Name", "Error", MessageBoxButtons.OK);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveAccount();
        }
    }
}
