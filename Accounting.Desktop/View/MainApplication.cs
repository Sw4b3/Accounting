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
using Accounting.Desktop.View.Dialog;
using Accounting.Models.Requests;

namespace Accounting.Desktop
{
    public partial class MainApplication : Form
    {
        private TransactionController _transactionController;
        private AccountController _accountController;
        private AnalyticsController _analyticsController;
        private ExcelController _excelController;

        public MainApplication()
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _analyticsController = new AnalyticsController();
            _excelController = new ExcelController();
            PopulationAll();
            Recalculate();
        }

        public void PopulationAll()
        {
            PopulationTransactionTable();
            PopulationTransferTable();
            PopulationTransferAnalysisTable();
            PopulationTransactionTablPersonalExpenses();
            PopulationTransactionTableWithdraw();
            populateAccountComboBox();
            populateTransferComboBox();
            Recalculate();
        }

        public void PopulationTransactionTable()
        {
            _transactionController.GetTransactions(dataViewTransaction, 1);
        }

        public void PopulationTransferTable()
        {
            _transactionController.GetTransactions(dataViewTransfer);
        }

        public void PopulationTransferAnalysisTable()
        {
            _analyticsController.GetAnalyticsOverview(dataGridViewAnalysis, chart1, chart2, chart3);
        }

        public void PopulationTransactionTableByDate()
        {
            _transactionController.SearchTransactionsByDate(dataViewTransaction, new SearchTransactionByDateRequest()
            {
                AccountTypeId = int.Parse((_accountController.GetAccountId(comboBoxAccount).ToString().Trim())),
                StartDate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")),
                EndDate = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd")),
            });
        }

        public void PopulationTransactionTablPersonalExpenses()
        {
            _transactionController.GetTransactionsPersonalExpenses(dataViewTransactionPE);
        }

        public void PopulationTransactionTableWithdraw()
        {
            _transactionController.GetTransactionsWithdraw(dataViewTransactionInc);
        }

        public void PopulateAccountTable()
        {
            _accountController.GetAccount(dataGridAccount);
        }

        public void populateAccountComboBox()
        {
            _accountController.GetAccountComboBox(comboBoxAccount);
        }

        public void populateTransferComboBox()
        {
            _accountController.GetAccountComboBox(comboBoxTransfer1);
            _accountController.GetAccountComboBox(comboBoxTransfer2);
        }

        public void FilterByAccount()
        {
            var accountId = _accountController.GetAccountId(comboBoxAccount);
            var balance = _accountController.GetAccountBalance(accountId);
            _transactionController.GetTransactions(dataViewTransaction, accountId);
            labelBalanceTransaction.Text = "Balance: " + balance;
        }

        public void Recalculate()
        {
            CalculateBalance();
            CalculateSubtotal();
        }

        public void CalculateSubtotal()
        {
            labelPersonalExpense.Text = "Subtotal: " + _transactionController.GetExpenseSubtotal().ToString();
            labelIncome.Text = "Subtotal: " + _transactionController.GetIncomeSubtotal().ToString();
        }


        public void CalculateBalance()
        {
            var accountId = _accountController.GetAccountId(comboBoxAccount);
            var balance = _accountController.GetAccountBalance(accountId);
            var availableBalance = _accountController.GetAccountAvaliableBalance(accountId);
            labelBalanceOverview.Text = "Balance: " + balance;
            labelBalanceTransaction.Text = "Balance: " + balance;
            labelAvailableBalanceTransaction.Text = "Available Balance: " + availableBalance;
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedTab.Name)
            {
                case "tabPage5":
                    PopulationAll();
                    break;
                case "tabPage6":
                    PopulateAccountTable();
                    break;
                default:
                    break;
            }
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            new TransactionAddDialog(_transactionController, this, 1).Show();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            new TransactionAddDialog(_transactionController, this, 2).Show();
        }

        private void FilterByDate_Click(object sender, EventArgs e)
        {
            PopulationTransactionTableByDate();
        }

        private void AddAccount_Click(object sender, EventArgs e)
        {
            new AccountDialog(this).Show();
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterByAccount();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            var transfer1 = _accountController.GetAccountId(comboBoxTransfer1);
            var transfer2 = _accountController.GetAccountId(comboBoxTransfer2);
            new TransferDialog(this, transfer1, transfer2).Show();
        }

        private void dataViewTransaction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new TransactionEditDialog(_transactionController.GetTransactionDetailsFromDataGridView(dataViewTransaction), this).Show();
        }

        private void dataViewTransaction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataViewTransaction[4, e.RowIndex].Value.ToString() == "Withdraw")
            {
                dataViewTransaction[5, e.RowIndex].Style.ForeColor = Color.FromArgb(245, 115, 101);
            }
            else
            {
                dataViewTransaction[5, e.RowIndex].Style.ForeColor = Color.FromArgb(103, 190, 86);
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            _excelController.ExportToTransactions();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            new ImportDialog(_transactionController,this).Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            //int selectedrowindex = dataViewTransaction.SelectedCells[0].RowIndex;
            //DataGridViewRow selectedRow = dataViewTransaction.Rows[selectedrowindex];

            //_transactionController.DeleteTransaction(new DeleteTransactionRequest { TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()) });
        }
    }
}
