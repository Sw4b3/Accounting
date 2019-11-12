using Accounting.Desktop.Controller;
using Accounting.Desktop.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.Desktop.View.Dialog
{
    public partial class ImportDialog : Form
    {
        private TransactionController _transactionController;
        private DataImportController _reportController;
        private AccountController _accountController;
        private MainApplication _mainform;
        private string _filename;

        public ImportDialog(MainApplication mainform, string filename)
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _reportController = new DataImportController();
            _filename = filename;
            _mainform = mainform;
            PopulateAccountComboBox();
        }


        public void PopulateAccountComboBox()
        {
            comboBoxAccounts.DataSource = _accountController.GetAccountsItem();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var accountTypeId = int.Parse(((AccountItem)comboBoxAccounts.SelectedItem).AccountId.ToString().Trim());

            _reportController.ImportFromExcel(_filename, accountTypeId);
            _mainform.PopulateTransactionTables();
            _mainform.FilterTransactionByAccount();
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
