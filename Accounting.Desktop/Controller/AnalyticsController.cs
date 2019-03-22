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

        public void GetAnalyticsOverview(DataGridView dataGridView, Chart chart, Chart chartBar)
        {
            var accountDetails = _transactionService.GetTransactions();
            var personalExpense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 3 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var generalExpense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.ExpenseId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var dayAnalytics = _transactionService.GetAnalyticsByDay().Select(x => x.Amount).ToList();
            var dayAnalyticsHeader = _transactionService.GetAnalyticsByDay().Select(x => x.TransactionTimestamp).ToList();
            chartBar.Series[0].Points.DataBindXY(dayAnalyticsHeader, dayAnalytics);
            chart.Series[0].Points.DataBindXY(new[] { "Personal Expense", "General Expense", "Income" }, new[] { personalExpense, generalExpense, income });
            dataGridView.DataSource = _transactionService.GetTransactionAnalysis();
        }
    }
}
