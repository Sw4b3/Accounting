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
        IList<Transaction> GetTransactionsRequest();

        IList<Transaction> GetTransactionsByDateRequest(GetTransactionByDateRequest request);

        IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request);

        IList<TransactionAnalysis> GetTransactionAnalysisRequest();

        void SaveTransactionsRequest(GetTransactionRequest request);

        void UpdateTransactionsRequest(UpdateTransactionRequest request);
    }
}
