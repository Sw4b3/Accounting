using Accounting.Desktop.Common;
using Accounting.Desktop.Controller;
using Accounting.Desktop.Model;
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
    public partial class TransactionAddDialog : Form
    {
        private TransactionController _transactionController;

        private AccountController _accountController;
        private MainApplication _mainform;
        private int _transactionType;

        public TransactionAddDialog(TransactionController transactionController, MainApplication mainform, int transactionType)
        {
            InitializeComponent();
            _transactionController = transactionController;

            _accountController = new AccountController();
            _mainform = mainform;
            _transactionType = transactionType;
            PopulateAccountComboBox();
        }

        public void SetTransaction()
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        public void PopulateAccountComboBox()
        {
            comboBoxAccounts.DataSource = _accountController.GetAccountsItem();
        }

        public void SaveTransaction() {
            if (Validator.IsNumber(textBox1.Text) && Validator.IsString(textBox3.Text))
            {
                _transactionController.SaveTransactionStaging(new SaveTransactionRequest
                {
                    Amount = decimal.Parse(textBox1.Text.Trim()),
                    AccountTypeId = int.Parse(((AccountItem)comboBoxAccounts.SelectedItem).AccountId.ToString().Trim()),
                    TransactionTypeId = _transactionType,
                    Description = textBox3.Text.ToUpper().Trim(),
                    TransactionTimestamp = dateTimePicker1.Value
                });
                _mainform.FilterTransactionByAccount();
                _mainform.PopulateTransactionLabels();
                this.Dispose();
            }
            else {
                MessageBox.Show("Please enter valid description and amount", "Error", MessageBoxButtons.OK);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveTransaction();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
