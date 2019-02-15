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

        IList<Transaction> GetTransactionsByDate(string connectionString, string _transaction, TransactionByDateRequest request);

        IList<TransactionAnalysis> GetTransactionAnalysis(string _connectionString, string _transaction);

        void SaveTransactions(string connectionString, string request, TransactionRequest transactions);

        void UpdateTransactions(string _connectionString, string _transaction, TransactionUpdateRequest request);

        IList<Expense> GetExpenses(string connectionString, string _transaction);
    }
}
