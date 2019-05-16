﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Desktop.Componets;
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
        private ExpenditureController _expenditureController;

        public MainApplication()
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _analyticsController = new AnalyticsController();
            _excelController = new ExcelController();
            _expenditureController = new ExpenditureController();
            PopulationAll();
            Recalculate();
        }

        public void PopulationAll()
        {
            PopulateTransactionTables();
            PopulateTransferTable();
            PopulateTransactionTablPersonalExpenses();
            PopulateTransactionTableWithdraw();
            PopulateAccountComboBox();
            PopulateTransferComboBox();
            Recalculate();
        }

        public void PopulateTransactionTables()
        {
            _transactionController.GetTransactions(dataViewTransaction, 1);
            _analyticsController.GetAnalyticsOverview(chart1);
        }

        public void PopulateTransferTable()
        {
            _transactionController.GetTransactions(dataViewTransfer);
        }

        public void PopulationAnalyticsTable()
        {
            _analyticsController.GetAnalyticStatistics(dataGridViewStatistics);
            _analyticsController.GetAnalyticsOverview(dataGridViewAnalysis);
            _analyticsController.GetAnalyticsByDay(dataGridViewDaily, chart2);
            _analyticsController.GetAnalyticsByMonth(dataGridViewMonthly,chart3);
        }

        public void PopulateExpenditureTable()
        {
            _transactionController.GetRecentTransactions(dataGridViewRecentTransactions);
            _expenditureController.PopluateExpenditurePanel(tableLayoutPanel1);
            _expenditureController.GetExpenditure(dataGridViewExpenditure);
            _expenditureController.GetExpenditureTypes(dataGridViewSetting);
            _expenditureController.GetExpenditureOverview(circularProgressBar1,labelRule1, labelCurrent1, labelLimit1, 
                circularProgressBar2, labelRule2, labelCurrent2, labelLimit2,
                circularProgressBar3,labelRule3, labelCurrent3, labelLimit3);
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

        public void PopulateTransactionTablPersonalExpenses()
        {
            _transactionController.GetTransactionsPersonalExpenses(dataViewTransactionPE);
        }

        public void PopulateTransactionTableWithdraw()
        {
            _transactionController.GetTransactionsWithdraw(dataViewTransactionInc);
        }

        public void PopulateAccountTable()
        {
            _accountController.GetAccount(dataGridAccount);
        }

        public void PopulateAccountComboBox()
        {
            _accountController.GetAccountComboBox(comboBoxAccount);
        }

        public void PopulateTransferComboBox()
        {
            _accountController.GetAccountComboBox(comboBoxTransfer1);
            _accountController.GetAccountComboBox(comboBoxTransfer2);
        }

        public void FilterTransactionByAccount()
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
                case "tabPage4":
                    PopulationAnalyticsTable();
                    break;
                case "tabPage12":
                    PopulateExpenditureTable();
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
            FilterTransactionByAccount();
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
            if (dataViewTransaction[5, e.RowIndex].Value!=null && dataViewTransaction[5, e.RowIndex].Value.ToString() != "Pending") {
                if (dataViewTransaction[4, e.RowIndex].Value.ToString() == "Withdraw")
                {
                    dataViewTransaction[5, e.RowIndex].Style.ForeColor = Color.FromArgb(245, 115, 101);
                }
                else
                {
                    dataViewTransaction[5, e.RowIndex].Style.ForeColor = Color.FromArgb(103, 190, 86);
                }
            }
        }

        private void Export_Click(object sender, EventArgs e)
        {
            _excelController.ExportToTransactions();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            new ImportDialog(_transactionController, this).Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _transactionController.DeleteTransaction(dataViewTransaction);
                FilterTransactionByAccount();
            }
            else if (dialogResult == DialogResult.No)
            {
            }

        }

        private void AddRule_Click(object sender, EventArgs e)
        {
            new ExpenditureTypeAddDialog(this).Show();
        }

        private void EditRule_Click(object sender, EventArgs e)
        {
            new ExpenditureTypeEditDialog(this,_expenditureController.GetExpenditureSettingsDetailsFromDataGridView(dataGridViewSetting)).Show();
        }

        private void ImportExpenditure_Click(object sender, EventArgs e)
        {
            _expenditureController.ImportExpenditure();
            PopulateExpenditureTable();
        }

        private void UpdateExtenditure_Click(object sender, EventArgs e)
        {
            _expenditureController.GetExpenditureDetailsFromDataGridView(dataGridViewExpenditure);
            PopulateExpenditureTable();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new AccountEditDialog(_accountController.GetAccountDetailsFromDataGridView(dataGridAccount), this).Show();
        }
    }
}
