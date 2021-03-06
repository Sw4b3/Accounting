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

namespace Accounting.Desktop.View.Dialog
{
    public partial class TransferDialog : Form
    {
        private TransactionController _transactionController;
        private MainApplication _mainform;
        private Validator _validator;
        private int _transfer1;
        private int _transfer2;

        public TransferDialog(MainApplication mainApplication, int transfer1, int transfer2)
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _validator = new Validator();
            _mainform = mainApplication;
            _transfer1 = transfer1;
            _transfer2 = transfer2;
        }

        public void TranferWithdraw()
        {
            _transactionController.SaveTransactionStaging(new SaveTransactionRequest
            {
                Amount = decimal.Parse(textBox3.Text),
                AccountTypeId = _transfer1,
                TransactionTypeId = 2,
                Description = "TRF "+textBox1.Text.ToString().ToUpper(),
                TransactionTimestamp = DateTime.Today
            });
        }

        public void TranferDepost()
        {
            _transactionController.SaveTransactionStaging(new SaveTransactionRequest
            {
                Amount = decimal.Parse(textBox3.Text),
                AccountTypeId = _transfer2,
                TransactionTypeId = 1,
                Description = "TRF " + textBox1.Text.ToString().ToUpper(),
                TransactionTimestamp = DateTime.Today
            });
        }

        public void SaveTransfer() {
            if (Validator.IsNumber(textBox3.Text))
            {
                TranferWithdraw();
                TranferDepost();
                _mainform.PopulationAll();
                _mainform.PopulateTransactionLabels();
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Please enter valid amount", "Error", MessageBoxButtons.OK);
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SaveTransfer();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


    }
}
