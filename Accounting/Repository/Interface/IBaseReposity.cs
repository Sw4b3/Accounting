using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IBaseRepository
    {
        IList<Transaction> GetTransactions(string connectionString, IDbConnection connection, IDbTransaction transaction);

        IList<Transaction> GetTransactionsByDate(string connectionString, TransactionByDateRequest request, IDbConnection connection, IDbTransaction transaction);

        IList<TransactionAnalysis> GetTransactionAnalysis(string _connectionString, IDbConnection connection, IDbTransaction transaction);

        void SaveTransactions(string connectionString, TransactionRequest transactions, IDbConnection connection, IDbTransaction transaction);

        void UpdateTransactions(string _connectionString, TransactionUpdateRequest request, IDbConnection connection, IDbTransaction transaction);

        IList<Expense> GetExpenses(string connectionString, IDbConnection connection, IDbTransaction transaction);
    }
}
