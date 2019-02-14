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
    public partial class TransactionAddDialog : Form
    {
        private TransactionController _transactionController;
        private ExpenseController _ExpenseController;
        private AccountController _AccountController;
        private MainApplication _mainform;
        private int _transactionType;

        public TransactionAddDialog(TransactionController transactionController, MainApplication mainform, int transactionType)
        {
            InitializeComponent();
            _transactionController = transactionController;
            _ExpenseController = new ExpenseController();
            _AccountController = new AccountController();
            _mainform = mainform;
            _transactionType = transactionType;
            populateExpenseComboBox();
            populateAccountComboBox();
        }

        public void populateExpenseComboBox()
        {
            _ExpenseController.GetExpenses(comboBox1);
        }

        public void populateAccountComboBox()
        {
            _AccountController.GetAccountComboBox(comboBox2);
        }

        public void SaveTransaction() {
            if (Validator.IsNumber(textBox1.Text) && Validator.IsString(textBox3.Text))
            {
                _transactionController.SaveTransaction(new TransactionRequest
                {
                    Amount = decimal.Parse(textBox1.Text.Trim()),
                    AccountTypeId = int.Parse((_AccountController.GetAccountId(comboBox2).ToString().Trim())),
                    TransactionTypeId = _transactionType,
                    ExpenseId = int.Parse(_ExpenseController.GetExpenseId(comboBox1).ToString().Trim()),
                    Description = textBox3.Text.Trim()
                });
                _mainform.PopulationAll();
                _mainform.Recalculate();
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
