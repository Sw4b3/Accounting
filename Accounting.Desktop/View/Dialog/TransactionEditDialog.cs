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
    public partial class TransactionEditDialog : Form
    {
        private TransactionController _transactionController;
        private MainApplication _mainform;
        private UpdateTransactionRequest _transactionRequest;


        public TransactionEditDialog(UpdateTransactionRequest transactionRequest, MainApplication mainApplication)
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _transactionRequest = transactionRequest;
            _mainform = mainApplication;
            setTransaction();
        }

        public void setTransaction() {
            textBox3.Text = _transactionRequest.Description;
            textBox1.Text = _transactionRequest.Amount.ToString();
            dateTimePicker1.Value = _transactionRequest.Date;
        }

        public void SaveTransaction() {
            if (Validator.IsNumber(textBox1.Text) && Validator.IsString(textBox3.Text))
            {
                _transactionController.UpdateTransaction(new UpdateTransactionRequest
                {
                    TransactionId = _transactionRequest.TransactionId,
                    Amount = decimal.Parse(textBox1.Text.Trim()),
                    Description = textBox3.Text.ToUpper().Trim(),
                    Date = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd"))
                });
                _mainform.PopulationAll();
                _mainform.Recalculate();
                this.Dispose();
            }
            else
            {
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
