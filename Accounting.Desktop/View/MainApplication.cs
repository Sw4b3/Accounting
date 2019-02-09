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
            PopulationTransactionTableGeneralExpenses();
            PopulationTransactionTablPersonalExpenses();
            PopulationTransactionTableWithdraw();
            Recalculate();
        }

        public void PopulationTransactionTableGeneralExpenses()
        {
            _transactionController.GetTransactionsGeneralExpenses(dataViewTransactionGE);
        }

        public void PopulationTransactionTablPersonalExpenses()
        {
            _transactionController.GetTransactionsPersonalExpenses(dataViewTransactionPE);
        }

        public void PopulationTransactionTableWithdraw()
        {
            _transactionController.GetTransactionsWithdraw(dataViewTransactionInc);
        }

        public void Recalculate()
        {
            CalculateBalance();
            CalculateSubtotal();
        }

        public void CalculateSubtotal()
        {
            label1.Text = "Subtotal: " + _transactionController.GetGeneralExpenseSubtotal().ToString();
            label2.Text = "Subtotal: " + _transactionController.GetPersonalExpenseSubtotal().ToString();
        }


        public void CalculateBalance()
        {
            labelBalance.Text = "Balance: "+_transactionController.GetTransactionBalance().ToString();
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            new TransactionView(_transactionController, this, 1).Show();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            new TransactionView(_transactionController, this, 2).Show();
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
