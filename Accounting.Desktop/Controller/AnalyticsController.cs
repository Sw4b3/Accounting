using Accounting.Domain.Services.Service;
using Accounting.Domain.Services.Utillies;
using Accounting.Models.Models;
using Accounting.Models.Service;
using System.Collections.Generic;
using System.Linq;

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

        public PieChartItem GetAnalyticsOverviewChart()
        {
            var accountDetails = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());

            var res = new PieChartItem()
            {
                Expense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum(),
                Income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum(),
            };

            return res;
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

        public BarChartItem GetAnalyticsByDayChart()
        {
            var transaction = _analyticsService.GetAnalyticsByDay();

            var res = new BarChartItem()
            {
                Data = transaction.Select(x => x.Amount).ToList(),
                Headers = transaction.Select(x => x.TransactionTimestamp.ToString("dd/MMM")).ToList(),
            };

            return res;
        }

        public IList<BarChartItem> GetAnalyticsByMonthChart()
        {
            var transaction = _analyticsService.GetAnalyticsByMonth();
            var credit = transaction.Select(x => x.Credit).ToList();
            var debit = transaction.Select(x => -x.Debit).ToList();
            var balance = transaction.Select(x => x.Balance).ToList();
            var month = transaction.Select(x => x.Date.ToString("MMM")).ToList();

            var res = new List<BarChartItem> {
                new BarChartItem(){
                       Headers = month,
                       Data = credit,
                },
                 new BarChartItem(){
                      Headers = month,
                      Data = debit,
                },
                  new BarChartItem(){
                       Headers = month,
                      Data = balance,

                },
            };

            return res;
        }
    }
}
