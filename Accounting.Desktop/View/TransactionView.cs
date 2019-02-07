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
        private MainApplication _mainform;
        private int _transactionType;

        public TransactionView(TransactionController transactionController, MainApplication mainform, int transactionType)
        {
            InitializeComponent();
            _transactionController = transactionController;
            _mainform = mainform;
            _transactionType = transactionType;
        }

        private void Save_Click(object sender, EventArgs e)
        {
            _transactionController.SaveTransaction(new TransactionRequest
            {
                Amount = decimal.Parse(textBox1.Text),
                AcounTypetId = int.Parse(textBox2.Text),
                TransactionTypeId = _transactionType
            });
            _mainform.PopulationTransactionTableDeposit();
            _mainform.PopulationTransactionTableWithdraw();
            _mainform.CalculateBalance();
            this.Dispose() ;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
