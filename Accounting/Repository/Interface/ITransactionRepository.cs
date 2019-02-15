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

        IList<Transaction> GetTransactionsByDateRequest(TransactionByDateRequest request);

        IList<TransactionAnalysis> GetTransactionAnalysisRequest();

        void SaveTransactionsRequest(TransactionRequest request);

        void UpdateTransactionsRequest(TransactionUpdateRequest request);
    }
}
