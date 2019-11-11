using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface ITransactionService
    {
        IList<Transaction> GetTransactionsByDate(DateRequest request);

        void SaveTransaction(SaveTransactionRequest transaction);

        void UpdateTransaction(UpdateTransactionRequest transaction);

        void DeleteTransaction(DeleteTransactionRequest transaction);
    }
}
