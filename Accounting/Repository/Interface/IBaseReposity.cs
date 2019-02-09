using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IBaseReposity
    {
        IList<Transaction> GetTransactions(string connectionString, string request);

        IList<Transaction> GetTransactionsByDate(string connectionString, string _transaction, TransactionRequest request);

        void SaveTransactions(string connectionString, string request, TransactionRequest transactions);

        IList<Expense> GetExpenses(string connectionString, string _transaction);
    }
}
