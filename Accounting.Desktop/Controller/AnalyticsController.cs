using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Utillies;
using Accounting.Models.Models;
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
        AnalyticsService _analyticsService;

        public AnalyticsController()
        {
            _transactionService = new TransactionService();
            _analyticsService = new AnalyticsService();
        }


        public List<AnalyticsOverview> GetAnalyticsOverview()
        {
            var res = _analyticsService.GetAnalysicOverview().ToList();
            return res;
        }

        public List<Statistic> GetAnalyticStatistics()
        {
            var res = _analyticsService.GetStatistics().ToList();
            return res;
        }

        public void GetAnalyticsOverview(Chart chartPie)
        {
            var accountDetails = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());
            var expense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();

            chartPie.Series[0].Points.DataBindXY(new[] { "Expense", "Income" }, new[] { expense, income });
        }

        public List<AnalysisByDay> GetAnalyticsByDay()
        {
            var res = _analyticsService.GetAnalyticsByDay().ToList();
            return res;
        }

        public List<AnalysisByMonth> GetAnalyticsByMonth()
        {
            var res = _analyticsService.GetAnalyticsByMonth().ToList();
            return res;
        }

        public void GetAnalyticsByDay(Chart chartBar)
        {
            var transaction = _analyticsService.GetAnalyticsByDay();
            var dayAnalytics = transaction.Select(x => x.Amount).ToList();
            var dayAnalyticsHeader = transaction.Select(x => x.TransactionTimestamp.ToString("dd/MMM")).ToList();

            chartBar.Series[0].Points.DataBindXY(dayAnalyticsHeader, dayAnalytics);
        }

        public void GetAnalyticsByMonth(Chart chartColumn)
        {
            var transaction = _analyticsService.GetAnalyticsByMonth();
            var credit = transaction.Select(x => x.Credit).ToList();
            var debit = transaction.Select(x => -x.Debit).ToList();
            var balance = transaction.Select(x => x.Balance).ToList();
            var month = transaction.Select(x => x.Date.ToString("MMM")).ToList();

            chartColumn.Series[0].Points.DataBindXY(month, credit);
            chartColumn.Series[1].Points.DataBindXY(month, debit);
            chartColumn.Series[2].Points.DataBindXY(month, balance);
        }
    }
}
