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
        private readonly TransactionService _transactionService;
        private readonly AnalyticsService _analyticsService;

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

        public ChartItem GetAnalyticsOverviewChart()
        {
            var accountDetails = _transactionService.GetTransactionsByDate(Extensions.GetCurrentMonth());
            var expense = accountDetails.Where(x => x.TransactionTypeId == 2 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();
            var income = accountDetails.Where(x => x.TransactionTypeId == 1 && x.AccountTypeId == 1).Select(x => x.Amount).Sum();

            var res = new ChartItem()
            {
                Headers = new string[]{
                     "Expense",
                     "Income"
                },
                Data = new decimal[]
                {
                     expense,
                      income,
                }
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

        public ChartItem GetAnalyticsByDayChart()
        {
            var transaction = _analyticsService.GetAnalyticsByDay();

            var res = new ChartItem()
            {
                Data = transaction.Select(x => x.Amount).ToList(),
                Headers = transaction.Select(x => x.TransactionTimestamp.ToString("dd/MMM")).ToList(),
            };

            return res;
        }

        public IList<ChartItem> GetAnalyticsByMonthChart()
        {
            var transaction = _analyticsService.GetAnalyticsByMonth();
            var credit = transaction.Select(x => x.Credit).ToList();
            var debit = transaction.Select(x => -x.Debit).ToList();
            var balance = transaction.Select(x => x.Balance).ToList();
            var month = transaction.Select(x => x.Date.ToString("MMM")).ToList();

            var res = new List<ChartItem> {
                new ChartItem(){
                       Headers = month,
                       Data = credit,
                },
                 new ChartItem(){
                      Headers = month,
                      Data = debit,
                },
                  new ChartItem(){
                       Headers = month,
                      Data = balance,

                },
            };

            return res;
        }

        public ChartItem GetAnalyticsSaving()
        {
            var transaction = _analyticsService.GetAnalyticsSavings();

            var res = new ChartItem()
            {
                Data = transaction.Select(x => x.Amount).ToList(),
                Headers = transaction.Select(x => x.Date.ToString("dd/MMM")).ToList(),
            };

            return res;
        }
    }
}
