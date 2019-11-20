using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;


namespace Accounting.Repository.Interface
{
    public interface ITransactionRepository
    {
        IList<Transaction> GetTransactionsByDateRequest(DateRequest request);

        IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request);

        void SaveTransactionRequest(SaveTransactionRequest request);

        void SaveTransactionStagingRequest(SaveTransactionRequest request);

        void UpdateTransactionRequest(UpdateTransactionRequest request);

        void DeleteTransactionStagingRequest(DeleteTransactionRequest request);

    }
}
