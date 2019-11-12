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
using Accounting.Models.Requests;

namespace Accounting.Desktop
{
    public partial class MainApplication : Form
    {
        private TransactionController _transactionController;
        private AccountController _accountController;
        private AnalyticsController _analyticsController;
        private DataImportController _reportController;
        private ExpenditureController _expenditureController;
        private DataImportController _dataImportController;
        private bool isInitialized = false;

        private Color SystemGreen = Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(227)))), ((int)(((byte)(145)))));
        private Color SystemRed = Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(147)))), ((int)(((byte)(137)))));

        public MainApplication()
        {
            InitializeComponent();
            _transactionController = new TransactionController();
            _accountController = new AccountController();
            _analyticsController = new AnalyticsController();
            _reportController = new DataImportController();
            _expenditureController = new ExpenditureController();
            _dataImportController = new DataImportController();
            PopulationAll();
        }

        public void PopulationAll()
        {
            PopulateTransactionTables();
            PopulateTransactionComboBoxs();
            PopulateTransactionLabels();
        }

        public void PopulateTransactionTables()
        {
            _transactionController.GetTransactions();
            _analyticsController.GetAnalyticsOverview(chart1);
            dataViewTransaction.DataSource = _transactionController.GetTransactions(1);
            dataViewTransfer.DataSource = _transactionController.GetTransfers();
            dataViewTransactionDebit.DataSource = _transactionController.GetTransactionsDebit();
            dataViewTransactionCredit.DataSource = _transactionController.GetTransactionsCredit();
            dataGridViewImportFile.DataSource = _reportController.GetImport();
            dataViewMapping.DataSource = _dataImportController.GetMappings();
        }

        public void PopulateAccountTable()
        {
            dataGridAccount.DataSource = _accountController.GetAccounts();
        }

        public void PopulationAnalyticsTable()
        {
            dataGridViewStatistics.DataSource = _analyticsController.GetAnalyticStatistics();
            dataGridViewAnalysis.DataSource = _analyticsController.GetAnalyticsOverview();
            dataGridViewDaily.DataSource = _analyticsController.GetAnalyticsByDay();
            dataGridViewMonthly.DataSource = _analyticsController.GetAnalyticsByMonth();
            _analyticsController.GetAnalyticsByDay(chartDayAnalytics);
            _analyticsController.GetAnalyticsByMonth(chartMonthAnalytics);
        }

        public void PopulateExpenditureTable()
        {
            DateTime date = dateTimePicker4.Value;
            comboBoxMappings.SelectedItem = "Unmapped";
            dataGridViewRecentTransactions.DataSource = _transactionController.GetRecentTransactions();

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


            dataGridViewExpenditure.DataSource = _expenditureController.GetExpenditure(date);
            dataGridViewExpenditure.AutoGenerateColumns = false;

            if (!isInitialized)
            {
                var _expenditureRule = new DataGridViewComboBoxColumn();

                _expenditureRule.DataSource = _expenditureController.GetExpenditureRulesList();
                _expenditureRule.HeaderText = "ExpenditureRuleId";
                _expenditureRule.DisplayMember = "ExpenditureDesc";
                _expenditureRule.ValueMember = "ExpenditureRuleId";
                _expenditureRule.FlatStyle = FlatStyle.Flat;

                dataGridViewExpenditure.Columns.Add(_expenditureRule);
                isInitialized = true;
            }

            dataGridViewSetting.DataSource = _expenditureController.GetExpenditureRules();
            dataGridExpenditureBreakdown.DataSource = _expenditureController.GetExpenditureBreakdown();
            _expenditureController.GetExpenditureOverview(circularProgressBar1, labelRule1, labelCurrent1, labelLimit1,
                circularProgressBar2, labelRule2, labelCurrent2, labelLimit2,
                circularProgressBar3, labelRule3, labelCurrent3, labelLimit3);
        }

        public void PopulateDataImportTables()
        {
            dataGridViewImportFile.DataSource = _reportController.GetImport();
            dataViewMapping.DataSource = _dataImportController.GetMappings();
        }

        public void PopulationTransactionTableByDate()
        {
            dataViewTransaction.DataSource = _transactionController.SearchTransactionsByDate(new SearchTransactionByDateRequest()
            {
                AccountTypeId = int.Parse(((AccountItem)comboBoxAccount.SelectedItem).AccountId.ToString().Trim()),
                StartDate = DateTime.Parse(dateTimePicker1.Value.ToString("yyyy-MM-dd")),
                EndDate = DateTime.Parse(dateTimePicker2.Value.ToString("yyyy-MM-dd")),
            });
        }

        public void PopulateTransactionComboBoxs()
        {
            comboBoxAccount.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferFrom.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferTo.DataSource = _accountController.GetAccountsItem();
            comboBoxTransferFrom.SelectedIndex = 1;
        }

        public void FilterTransactionByAccount()
        {
            var accountId = ((AccountItem)comboBoxAccount.SelectedItem).AccountId;

            var balance = _accountController.GetAccountBalance(accountId);
            _transactionController.GetTransactions();
            dataViewTransaction.DataSource = _transactionController.GetTransactions(1);
            PopulateBalanceLabel();
        }

        public void PopulateTransactionLabels()
        {
            PopulateBalanceLabel();
            PopulateSubtotalLabel();
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

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedTab.Name)
            {
                case "transactionsTab":
                    PopulationAll();
                    break;
                case "analyticsTab":
                    PopulationAnalyticsTable();
                    break;
                case "accountTab":
                    PopulateAccountTable();
                    break;
                case "expenditureTab":
                    PopulateExpenditureTable();
                    break;
                case "dataImportTab":
                    PopulateDataImportTables();
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
            var transfer1 = ((AccountItem)comboBoxTransferFrom.SelectedItem).AccountId;
            var transfer2 = ((AccountItem)comboBoxTransferTo.SelectedItem).AccountId;
            new TransferDialog(this, transfer1, transfer2).Show();
        }

        private void dataViewTransaction_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            new TransactionEditDialog(GetTransactionDetailsFromDataGridView(dataViewTransaction), this).Show();
        }

        public UpdateTransactionRequest GetTransactionDetailsFromDataGridView(DataGridView dataGridView)
        {
            if (!dataGridView.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridView.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView.Rows[selectedrowindex];
                return new UpdateTransactionRequest
                {
                    TransactionId = Guid.Parse(selectedRow.Cells[0].Value.ToString()),
                    Description = selectedRow.Cells[1].Value.ToString(),
                    Amount = decimal.Parse(selectedRow.Cells[2].Value.ToString()),
                    Date = DateTime.Parse(selectedRow.Cells[3].Value.ToString())
                };
            }
            return null;
        }

        private void dataViewTransaction_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataViewTransaction[5, e.RowIndex].Value != null && dataViewTransaction[5, e.RowIndex].Value.ToString() != "Pending")
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
        }

        private void dataGridExpenditureBreakdown_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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

        private void Export_Click(object sender, EventArgs e)
        {
            _reportController.ExportToTransactions();
        }


        private void ExportAll_Click(object sender, EventArgs e)
        {
            _reportController.ExportToAllTransactions();
        }

        private void Import_Click(object sender, EventArgs e)
        {
            _reportController.OpenFileDialog(this);
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

        private void AddRule_Click(object sender, EventArgs e)
        {
            new ExpenditureTypeAddDialog(this).Show();
        }

        private void EditRule_Click(object sender, EventArgs e)
        {
            new ExpenditureTypeEditDialog(this, _expenditureController.GetExpenditureSettingsDetailsFromDataGridView(dataGridViewSetting)).Show();
        }

        private void DeleteRule_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Rule", "Delete Rule", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewSetting.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewSetting.Rows[selectedrowindex];
                _expenditureController.DeleteExpenditureRule(int.Parse(selectedRow.Cells[0].Value.ToString()));
                dialogResult = MessageBox.Show("Rule Deleted", "Delete Rule", MessageBoxButtons.OK);

                DateTime date = dateTimePicker4.Value;
                _expenditureController.GetExpenditureDetailsFromDataGridView(dataGridViewExpenditure);
                dataGridViewExpenditure.DataSource = _expenditureController.FilterExpenditure(comboBoxMappings.SelectedItem.ToString(), date);
                dataGridExpenditureBreakdown.DataSource = _expenditureController.FilterExpenditureBreakdownByDate(date);
            }
        }

        private void ImportExpenditure_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker4.Value;
            _expenditureController.ImportExpenditure(date);
            PopulateExpenditureTable();
        }

        private void UpdateExtenditure_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker4.Value;
            _expenditureController.GetExpenditureDetailsFromDataGridView(dataGridViewExpenditure);
            dataGridViewExpenditure.DataSource = _expenditureController.FilterExpenditure(comboBoxMappings.SelectedItem.ToString(), date);
            dataGridExpenditureBreakdown.DataSource = _expenditureController.FilterExpenditureBreakdownByDate(date);
        }

        private void EditAccount_Click(object sender, EventArgs e)
        {
            if (!dataGridAccount.SelectedRows.Count.Equals(0))
            {
                int selectedrowindex = dataGridAccount.SelectedCells[1].RowIndex;
                DataGridViewRow selectedRow = dataGridAccount.Rows[selectedrowindex];
                var update = new UpdateAccountRequest
                {
                    AccountId = int.Parse(selectedRow.Cells[1].Value.ToString()),
                };

                new AccountEditDialog(update, this).Show();
            }
        }

        private void comboBoxMappings_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker4.Value;
            dataGridViewExpenditure.DataSource = _expenditureController.FilterExpenditure(comboBoxMappings.SelectedItem.ToString(), date);
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker3.Value;
            dataGridExpenditureBreakdown.DataSource = _expenditureController.FilterExpenditureBreakdownByDate(date);
        }

        private void Rollback_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Rollback this Import", "Rollback Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _reportController.RollbackImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _reportController.GetImport();
            }
        }

        private void Complete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to complete this Import", "Complete Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _reportController.CompleteImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _reportController.GetImport();
            }
        }

        private void DeleteImport_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Import", "Delete Import", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataGridViewImportFile.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridViewImportFile.Rows[selectedrowindex];
                _reportController.DeleteImport(Guid.Parse(selectedRow.Cells[0].Value.ToString()));
                FilterTransactionByAccount();
                dataGridViewImportFile.DataSource = _reportController.GetImport();
            }
        }

        private void DeleteMapping_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete this Mapping", "Delete Mapping", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int selectedrowindex = dataViewMapping.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataViewMapping.Rows[selectedrowindex];
                _reportController.DeleteMapping(int.Parse(selectedRow.Cells[0].Value.ToString()));
                dataViewMapping.DataSource = _reportController.GetMappings();
            }
        }

        private void DateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker4.Value;
            dataGridViewExpenditure.DataSource = _expenditureController.GetExpenditure(date);
        }

        private void AddMapping_Click(object sender, EventArgs e)
        {
            new MappingAddDialog(this).Show();
        }
    }
}

