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
    public partial class AccountView : Form
    {
        private AccountController _accountController;
        private MainApplication _mainForm;

        public AccountView(MainApplication mainForm)
        {
            InitializeComponent();

            _accountController = new AccountController();
            _mainForm = mainForm;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _accountController.SaveAccount(new AccountRequest {
                AccountType = textBox3.Text,
            });
            _mainForm.PopulateAccountTable();
            this.Dispose();
        }
    }
}
