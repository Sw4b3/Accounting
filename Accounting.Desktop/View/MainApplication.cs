using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Desktop.Componets;
using Accounting.Desktop.Controller;
using Accounting.Desktop.Model;
using Accounting.Desktop.View;
using Accounting.Desktop.View.Dialog;
using Accounting.Models.Models;
using Accounting.Models.Requests;

namespace Accounting.Desktop
{
    public partial class MainApplication : Form
    {
        private TransactionController _transactionController;
        private AccountController _accountController;
        private AnalyticsController _analyticsController;
        private DataImportController _DataImportController;
        private ExpenditureController _expenditureController;
        private DataImportController _dataImportController;
        private bool isInitialized = false;

        private Color SystemGreen = Color.FromArgb(184, 227, 145);
        private Color SystemGreenForecolor = Color.FromArgb(103, 190, 86);
        private Color SystemRed = Color.FromArgb(247, 147, 137);
        private Color SystemRedForecolor = Color.FromArgb(245, 115, 101);

        public MainApplication()
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _analyticsController = new AnalyticsController();
            _DataImportController = new DataImportController();
            _expenditureController = new ExpenditureController();
            _dataImportController = new DataImportController();
            PopulationTransactionPage();
        }

        #region Transactions Page

        public void PopulationTransactionPage()
        {
            PopulateTransactionTables();
            PopulateTransactionCharts();
            PopulateTransactionComboBoxs();
            PopulateTransactionLabels();
        }

        public void PopulateTransactionTables()
        {
            _transactionController.GetTransactions();
            dataViewTransaction.DataSource = _transactionController.GetTransactions(1);
            dataViewTransfer.DataSource = _transactionController.GetTransfers();
            dataViewTransactionDebit.DataSource = _transactionController.GetTransactionsDebit();
            dataViewTransactionCredit.DataSource = _transactionController.GetTransactionsCredit();
        }

        public void PopulateTransactionCharts()
        {
            var chartData = _analyticsController.GetAnalyticsOverviewChart();
            chartTransactionOverview.Series[0].Points.DataBindXY(chartData.Headers, chartData.Data);
        }

        public void PopulateTransactionComboBoxs()
        {
            comboBoxAccount.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferFrom.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferTo.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferFrom.SelectedIndex = 1;
        }

        public void PopulateTransactionLabels()
        {
            PopulateBalanceLabel();
            PopulateSubtotalLabel();
        }

        public void PopulationTransactionTableByDate()
        {
            dataViewTransaction.DataSource = _transactionController.SearchTransactionsByDate(new SearchTransactionByDateRequest()
            {
                AccountTypeId = int.Parse(((AccountItem)comboBoxAccount.SelectedItem).AccountId.ToString().Trim()),
                StartDate = DateTime.Parse(dateTimePickerStartDate.Value.ToString("yyyy-MM-dd")),
                EndDate = DateTime.Parse(dateTimePickerEndDate.Value.ToString("yyyy-MM-dd")),
            });
        }

        public void FilterTransactionByAccount()
        {
            var accountId = ((AccountItem)comboBoxAccount.SelectedItem).AccountId;
            _transactionController.GetTransactions();

            dataViewTransaction.DataSource = _transactionController.GetTransactions(accountId);
            PopulateBalanceLabel();
        }

        public void PopulateSubtotalLabel()
        {
            labelPersonalExpense.Text = "Subtotal: " + _transactionController.GetExpenseSubtotal().ToString();
            labelIncome.Text = "Subtotal: " + _transactionController.GetIncomeSubtotal().ToString();
        }

        public void PopulateBalanceLabel()
        {
            var accountId = ((AccountItem)comboBoxAccount.SelectedItem).AccountId;
            var balance = _accountController.GetAccountBalance(accountId);
            var availableBalance = _accountController.GetAccountAvaliableBalance(accountId);
            labelBalanceOverview.Text = "Balance: " + balance;
            labelBalanceTransaction.Text = "Balance: " + balance;
            labelAvailableBalanceTransaction.Text = "Available Balance: " + availableBalance;
        }

        private void DataViewTransaction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dataViewTransaction.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataViewTransaction.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataViewTransaction.Rows[selectedrowindex];
                var res = new UpdateTransactionRequest
                {
                    TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()),
                    Description = selectedRow.Cells[1].Value.ToString(),
                    Amount = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                    Date = DateTime.Parse(selectedRow.Cells[3].Value.ToString())
                };
                new TransactionEditDialog(res, this).Show();
            }
        }

        private void DataViewTransaction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataViewTransaction[5, e.RowIndex].Value != null && dataViewTransaction[5, e.RowIndex].Value.ToString() != "Pending")
            {
                if (dataViewTransaction[4, e.RowIndex].Value.ToString() == "Withdraw")
                {
                    dataViewTransaction[5, e.RowIndex].Style.ForeColor = SystemRedForecolor;
                }
                else
                {
                    dataViewTransaction[5, e.RowIndex].Style.ForeColor = SystemGreenForecolor;
                }
            }
        }

        private void ComboBoxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterTransactionByAccount();
        }

        private void Deposit_Click(object sender, EventArgs e)
        {
            new TransactionAddDialog(_transactionController, this, 1).Show();
        }

        private void Withdraw_Click(object sender, EventArgs e)
        {
            new TransactionAddDialog(_transactionController, this, 2).Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this record", "Delete", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataViewTransaction.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataViewTransaction.Rows[selectedrowindex];
                var transactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString());

                _transactionController.DeleteTransaction(transactionId);
                _transactionController.GetTransactions();
                dataViewTransfer.DataSource = _transactionController.GetTransfers();
                dataViewTransactionDebit.DataSource = _transactionController.GetTransactionsDebit();
                dataViewTransactionCredit.DataSource = _transactionController.GetTransactionsCredit();
                FilterTransactionByAccount();
                PopulateTransactionLabels();
            }
        }

        private void FilterByDate_Click(object sender, EventArgs e)
        {
            PopulationTransactionTableByDate();
        }

        private void Transfer_Click(object sender, EventArgs e)
        {
            var transfer1 = ((AccountItem)comboBoxTransferFrom.SelectedItem).AccountId;
            var transfer2 = ((AccountItem)comboBoxTransferTo.SelectedItem).AccountId;
            new TransferDialog(this, transfer1, transfer2).Show();
        }

        #endregion

        #region Expenditure Page

        public void PopulateExpenditurePage()
        {
            PopulateExpenditureTable();
            PopulateExpenditureTableLayout();
            PopulateExpenditureCharts();
        }

        public void PopulateExpenditureTable()
        {
            var date = dateTimePickerExpitureOverview.Value;
            comboBoxExpenditureFilter.SelectedItem = "Unmapped";

            dataGridViewSetting.DataSource = _expenditureController.GetExpenditureRules();
            dataGridViewRecentTransactions.DataSource = _transactionController.GetRecentTransactions();
            dataGridExpenditureBreakdown.DataSource = _expenditureController.GetExpenditureBreakdown();
            dataGridExpenditure.AutoGenerateColumns = false;

            if (!isInitialized)
            {
                var _expenditureRule = new DataGridViewComboBoxColumn();

                _expenditureRule.DataSource = _expenditureController.GetExpenditureRulesList();
                _expenditureRule.HeaderText = "ExpenditureRuleId";
                _expenditureRule.DisplayMember = "ExpenditureDesc";
                _expenditureRule.ValueMember = "ExpenditureRuleId";
                _expenditureRule.FlatStyle = FlatStyle.Flat;

                dataGridExpenditure.Columns.Add(_expenditureRule);
                isInitialized = true;
            }
        }

        public void PopulateExpenditureTableLayout()
        {
            var expenditureOverview = _expenditureController.GetExpenditureRuleOverview();

            tableLayoutPanel.Controls.Clear();

            foreach (var item in expenditureOverview)
            {
                if (item.ShouldDisplay && item.ExpenditureLimit != 0)
                {
                    //tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
                    tableLayoutPanel.Controls.Add(new Label()
                    {
                        Text = item.ExpenditureDesc.ToString()
                    });

                    if (item.ExpenditureTotal <= item.ExpenditureLimit)
                    {
                        tableLayoutPanel.Controls.Add(new CustomProgressBar()
                        {
                            Maximum = (int)item.ExpenditureLimit,
                            Value = (int)item.ExpenditureTotal,
                            BackColor = Color.WhiteSmoke,
                            ForeColor = SystemGreen,
                            Width = 200
                        });
                    }
                    else
                    {
                        tableLayoutPanel.Controls.Add(new CustomProgressBar()
                        {
                            Maximum = (int)item.ExpenditureLimit,
                            Value = (int)item.ExpenditureLimit,
                            BackColor = Color.WhiteSmoke,
                            ForeColor = SystemRed,
                            Width = 200
                        });
                    }
                }
            }
        }

        public void PopulateExpenditureCharts()
        {

            GetExpenditureOverview(circularProgressBar1, labelRule1, labelCurrent1, labelLimit1,
                circularProgressBar2, labelRule2, labelCurrent2, labelLimit2,
                circularProgressBar3, labelRule3, labelCurrent3, labelLimit3);
        }

        public void GetExpenditureOverview(CircularProgressBar.CircularProgressBar bar1, Label rule1, Label current1, Label limit1,
                                         CircularProgressBar.CircularProgressBar bar2, Label rule2, Label current2, Label limit2,
                                         CircularProgressBar.CircularProgressBar bar3, Label rule3, Label current3, Label limit3)
        {
            var expenditureOverview = _expenditureController.GetExpenditureOverview();

            if (expenditureOverview.Count != 0)
            {
                var debitExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Debit Expense");

                bar1.Maximum = (int)debitExpense.ExpenditureLimit;
                rule1.Text = debitExpense.ExpenditureDesc;

                current1.Text = "Current: " + debitExpense.ExpenditureTotal.ToString();
                limit1.Text = "Limit: " + debitExpense.ExpenditureLimit.ToString();

                if (debitExpense.ExpenditureTotal <= debitExpense.ExpenditureLimit)
                {
                    bar1.Value = (int)debitExpense.ExpenditureTotal;
                }
                else
                {
                    bar1.Value = (int)debitExpense.ExpenditureLimit;
                    bar1.ProgressColor = SystemRed;
                }

                var livingExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Living Expense");

                bar2.Maximum = (int)livingExpense.ExpenditureLimit;
                rule2.Text = livingExpense.ExpenditureDesc;

                current2.Text = "Current: " + livingExpense.ExpenditureTotal.ToString();
                limit2.Text = "Limit: " + livingExpense.ExpenditureLimit.ToString();

                if (livingExpense.ExpenditureTotal <= livingExpense.ExpenditureLimit)
                {
                    bar2.Value = (int)livingExpense.ExpenditureTotal;
                }
                else
                {
                    bar2.Value = (int)livingExpense.ExpenditureLimit;
                    bar2.ProgressColor = SystemRed;
                }

                var otherExpense = expenditureOverview.FirstOrDefault(eo => eo.ExpenditureDesc == "Other Expense");

                bar3.Maximum = (int)otherExpense.ExpenditureLimit;
                rule3.Text = otherExpense.ExpenditureDesc;

                current3.Text = "Current: " + otherExpense.ExpenditureTotal.ToString();
                limit3.Text = "Limit: " + otherExpense.ExpenditureLimit.ToString();

                if (otherExpense.ExpenditureTotal <= otherExpense.ExpenditureLimit)
                {
                    bar3.Value = (int)otherExpense.ExpenditureTotal;
                }
                else
                {
                    bar3.Value = (int)otherExpense.ExpenditureLimit;
                    bar3.ProgressColor = SystemRed;
                }
            }
        }

        private void DataGridExpenditureBreakdown_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridExpenditureBreakdown[3, e.RowIndex].Value != null)
            {
                if (dataGridExpenditureBreakdown[3, e.RowIndex].Value.ToString().Contains("-"))
                {
                    dataGridExpenditureBreakdown[3, e.RowIndex].Style.ForeColor = Color.FromArgb(245, 115, 101);
                }
                else
                {
                    dataGridExpenditureBreakdown[3, e.RowIndex].Style.ForeColor = Color.FromArgb(103, 190, 86);
                }
            }
        }

        private void ComboBoxExpenditureFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var type = comboBoxExpenditureFilter.SelectedItem.ToString();
            DateTime date = dateTimePickerExpitureOverview.Value;
            dataGridExpenditure.DataSource = _expenditureController.GetExpenditure(type, date);

            if (type.Equals("Unmapped"))
            {
                dataGridExpenditure.Columns["ExpenditureDesc"].Visible = false;
            }
            else
            {
                dataGridExpenditure.Columns["ExpenditureDesc"].Visible = true;
            }
        }

        private void DateTimePickerExpenditure_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerExpenditure.Value;
            dataGridExpenditureBreakdown.DataSource = _expenditureController.FilterExpenditureBreakdownByDate(date);
        }

        private void AddRule_Click(object sender, EventArgs e)
        {
            new ExpenditureTypeAddDialog(this).Show();
        }

        private void EditRule_Click(object sender, EventArgs e)
        {
            if (!dataGridViewSetting.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridViewSetting.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewSetting.Rows[selectedrowindex];
                var res = new UpdateExpenditureRuleRequest
                {
                    ExpenditureRuleId = int.Parse(selectedRow.Cells[0].Value.ToString()),
                    ExpenditureDesc = selectedRow.Cells[1].Value.ToString(),
                    ExpenditureLimit = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                    ShouldDisplay = bool.Parse(selectedRow.Cells[3].Value.ToString()),
                };

                new ExpenditureTypeEditDialog(this, res).Show();
            }
        }

        private void DeleteRule_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Rule", "Delete Rule", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewSetting.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewSetting.Rows[selectedrowindex];
                _expenditureController.DeleteExpenditureRule(int.Parse(selectedRow.Cells[0].Value.ToString()));

                dataGridViewSetting.DataSource = _expenditureController.GetExpenditureRules();

                MessageBox.Show("Rule Deleted", "Delete Rule", MessageBoxButtons.OK);
            }
        }

        private void ImportExpenditure_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerExpitureOverview.Value;
            _expenditureController.ImportExpenditure(date);
            PopulateExpenditureTable();
        }

        private void UpdateExtenditure_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerExpitureOverview.Value;

            if (!dataGridExpenditure.SelectedRows.Count.Equals(0))
            {
                foreach (DataGridViewRow rows in dataGridExpenditure.Rows)
                {
                    if (rows.Cells[6].Value != null)
                    {
                        _expenditureController.UpdateExpenditure(new UpdateExpenditureRequest
                        {
                            ExpenditureId = Guid.Parse(rows.Cells[0].Value.ToString()),
                            ExpenditureRuleId = int.Parse(rows.Cells[6].Value.ToString())
                        });
                    }

                }
            }

            dataGridExpenditure.DataSource = _expenditureController.GetExpenditure(comboBoxExpenditureFilter.SelectedItem.ToString(), date);
            dataGridExpenditureBreakdown.DataSource = _expenditureController.FilterExpenditureBreakdownByDate(date);
        }

        private void DateTimePickerExpitureOverview_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePickerExpitureOverview.Value;
            dataGridExpenditure.DataSource = _expenditureController.GetExpenditure(comboBoxExpenditureFilter.SelectedItem.ToString(), date);
        }

        #endregion

        #region Data Import Page

        public void PopulateDataImportTables()
        {
            dataGridViewImportFile.DataSource = _DataImportController.GetImports();
            dataViewMapping.DataSource = _dataImportController.GetMappings();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            _DataImportController.OpenFileDialog(this);
        }

        private void Export_Click(object sender, EventArgs e)
        {
            _DataImportController.ExportToTransactions();
        }

        private void ExportAll_Click(object sender, EventArgs e)
        {
            _DataImportController.ExportToAllTransactions();
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to complete this Import", "Complete Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _DataImportController.CompleteImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _DataImportController.GetImports();
            }
        }

        private void Rollback_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Rollback this Import", "Rollback Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _DataImportController.RollbackImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _DataImportController.GetImports();
            }
        }

        private void DeleteImport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Import", "Delete Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _DataImportController.DeleteImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _DataImportController.GetImports();
            }
        }

        private void AddMapping_Click(object sender, EventArgs e)
        {
            new MappingAddDialog(this).Show();
        }

        private void DeleteMapping_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Mapping", "Delete Mapping", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataViewMapping.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataViewMapping.Rows[selectedrowindex];
                _DataImportController.DeleteMapping(int.Parse(selectedRow.Cells[0].Value.ToString()));
                dataViewMapping.DataSource = _DataImportController.GetMappings();
            }
        }

        #endregion

        #region Analytics Page

        public void PopulationAnalyticsPage()
        {
            PopulationAnalyticsTable();
            PopulationAnalyticsCharts();
        }

        public void PopulationAnalyticsTable()
        {
            dataGridViewStatistics.DataSource = _analyticsController.GetAnalyticStatistics();
            dataGridViewAnalysis.DataSource = _analyticsController.GetAnalyticsOverview();
            dataGridViewDaily.DataSource = _analyticsController.GetAnalyticsByDay();
            dataGridViewMonthly.DataSource = _analyticsController.GetAnalyticsByMonth();
        }

        public void PopulationAnalyticsCharts()
        {
            var chartData = _analyticsController.GetAnalyticsByDayChart();
            chartDayAnalytics.Series[0].Points.DataBindXY(chartData.Headers, chartData.Data);

            var chartDataColum = _analyticsController.GetAnalyticsByMonthChart();

            chartMonthAnalytics.Series[0].Points.DataBindXY(chartDataColum[0].Headers, chartDataColum[0].Data);
            chartMonthAnalytics.Series[1].Points.DataBindXY(chartDataColum[1].Headers, chartDataColum[1].Data);
            chartMonthAnalytics.Series[2].Points.DataBindXY(chartDataColum[2].Headers, chartDataColum[2].Data);
        }

        #endregion

        #region Accounts Page

        public void PopulateAccountTable()
        {
            dataGridAccount.DataSource = _accountController.GetAccounts();
        }

        private void AddAccount_Click(object sender, EventArgs e)
        {
            new AccountDialog(this).Show();
        }

        private void EditAccount_Click(object sender, EventArgs e)
        {
            if (!dataGridAccount.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridAccount.SelectedCells[1].RowIndex;
                DataGridViewRow selectedRow = dataGridAccount.Rows[selectedrowindex];
                var res = new UpdateAccountRequest
                {
                    AccountId = int.Parse(selectedRow.Cells[1].Value.ToString()),
                };

                new AccountEditDialog(res, this).Show();
            }
        }

        #endregion

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlMain.SelectedTab.Name)
            {
                case "transactionsTab":
                    PopulationTransactionPage();
                    break;
                case "expenditureTab":
                    PopulateExpenditurePage();
                    break;
                case "dataImportTab":
                    PopulateDataImportTables();
                    break;
                case "analyticsTab":
                    PopulationAnalyticsPage();
                    break;
                case "accountTab":
                    PopulateAccountTable();
                    break;
                default:
                    break;
            }
        }

        private void Shutdown_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

