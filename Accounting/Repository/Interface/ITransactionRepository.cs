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
        IList<Transaction> GetTransactionsByDateRequest(GetDateRequest request);

        IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request);

        void SaveTransactionRequest(SaveTransactionRequest request);

        void SaveTransactionStagingRequest(SaveTransactionRequest request);

        void UpdateTransactionRequest(UpdateTransactionRequest request);

        void DeleteTransactionStagingRequest(DeleteTransactionRequest request);
    }
}
