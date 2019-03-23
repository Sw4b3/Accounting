using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Accounting.Repository.Interface
{
    public interface ITransactionRepository
    {
        IList<Transaction> GetTransactionsByDateRequest(GetTransactionByDateRequest request);

        IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request);

        IList<TransactionAnalyticsOverview> GetAnalyticOverviewRequest(GetTransactionByDateRequest request);

        IList<TransactionAnalyticsByDay> GetAnalyticsByDayRequest(GetTransactionByDateRequest request);

        IList<TransactionAnalyticsByMonth> GetAnalyticsByMonthRequest();

        void SaveTransactionsRequest(GetTransactionRequest request);

        void UpdateTransactionsRequest(UpdateTransactionRequest request);
    }
}
