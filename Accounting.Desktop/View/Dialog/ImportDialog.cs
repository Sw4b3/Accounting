﻿using Accounting.Desktop.Controller;
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

        public ImportDialog(TransactionController transactionController, MainApplication mainform, string filename)
        {
            InitializeComponent();
            _transactionController = transactionController;
            _accountController = new AccountController();
            _reportController = new DataImportController();
            _filename = filename;
            _mainform = mainform;
            PopulateAccountComboBox();
        }


        public void PopulateAccountComboBox()
        {
            _accountController.GetAccountComboBox(comboBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var accountTypeId = int.Parse((_accountController.GetAccountId(comboBox2).ToString().Trim()));
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
