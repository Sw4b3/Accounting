﻿using Accounting.Desktop.Common;
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
    public partial class TransactionView : Form
    {
        private TransactionController _transactionController;
        private ExpenseController _ExpenseController;
        private AccountController _AccountController;
        private MainApplication _mainform;
        private Validator _validator;
        private int _transactionType;

        public TransactionView(TransactionController transactionController, MainApplication mainform, int transactionType)
        {
            InitializeComponent();
            _transactionController = transactionController;
            _ExpenseController = new ExpenseController();
            _AccountController = new AccountController();
            _validator = new Validator();
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
            if (_validator.IsNumber(textBox1.Text) && _validator.IsString(textBox3.Text))
            {
                _transactionController.SaveTransaction(new TransactionRequest
                {
                    Amount = decimal.Parse(textBox1.Text),
                    AcounTypetId = int.Parse((_AccountController.GetAccountId(comboBox2).ToString())),
                    TransactionTypeId = _transactionType,
                    ExpenseId = int.Parse(_ExpenseController.GetExpenseId(comboBox1).ToString()),
                    Description = textBox3.Text
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
