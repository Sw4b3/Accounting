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

        IList<AnalyticsOverview> GetAnalyticOverviewRequest(GetTransactionByDateRequest request);

        IList<AnalysisByDay> GetAnalyticsByDayRequest(GetTransactionByDateRequest request);

        IList<AnalysisByMonth> GetAnalyticsByMonthRequest();

        void SaveTransactionsRequest(GetTransactionRequest request);

        void UpdateTransactionsRequest(UpdateTransactionRequest request);

        void DeleteTransactionsRequest(DeleteTransactionRequest request);
    }
}
