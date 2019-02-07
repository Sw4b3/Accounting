using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Desktop.Controller;
using Accounting.Desktop.View;
using Accounting.Repository;

namespace Accounting.Desktop
{
    public partial class MainApplication : Form
    {
        private TransactionController _transactionController;

        public MainApplication()
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            PopulationTransactionTable();
        }

        public void PopulationTransactionTable()
        {
            _transactionController.GetTransactions(dataViewTransaction);
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            new Transaction(_transactionController,this,1).Show();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            new Transaction(_transactionController, this, 2).Show();
        }
    }
}
