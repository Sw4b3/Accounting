using Accounting.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Accounting.Desktop.Controller
{
    class AnalyticsController
    {
        TransactionService _transactionService;

        public AnalyticsController()
        {
            _transactionService = new TransactionService();
        }

        public void GetAnalyticsOverview(DataGridView dataGridView, Chart chartPie, Chart chartBar, Chart chartColumn)
        {
            var accountDetails = _transactionService.GetTransactions();
            var personalExpense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var generalExpense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();

            var dayAnalytics = _transactionService.GetAnalyticsByDay().Select(x => x.Amount).ToList();
            var dayAnalyticsHeader = _transactionService.GetAnalyticsByDay().Select(x => x.TransactionTimestamp.ToString("dd/MMM")).ToList();

            var credit = _transactionService.GetAnalyticsByMonth().Select(x => x.Credit).ToList();
            var debit = _transactionService.GetAnalyticsByMonth().Select(x => -x.Debit).ToList();
            var balance = _transactionService.GetAnalyticsByMonth().Select(x => x.Balance).ToList();
            var month = _transactionService.GetAnalyticsByMonth().Select(x => x.Date.ToString("MMM")).ToList();

            chartColumn.Series[0].Points.DataBindXY(month,credit);
            chartColumn.Series[1].Points.DataBindXY(month,debit);
            chartColumn.Series[2].Points.DataBindXY(month, balance);

            chartBar.Series[0].Points.DataBindXY(dayAnalyticsHeader, dayAnalytics);
            chartPie.Series[0].Points.DataBindXY(new[] { "Personal Expense", "General Expense", "Income" }, new[] { personalExpense, generalExpense, income });
            dataGridView.DataSource = _transactionService.GetTransactionAnalysis();
        }
    }
}
