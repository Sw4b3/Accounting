using Accounting.Repository.Interface;
using Accounting.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System;
using Accounting.Models.Requests;
using System.Data;

namespace Accounting.Repository.Common
{
    public class BaseRepository : IBaseReposity
    {
        DapperRepository _dapperRepository = new DapperRepository();

        public IList<Transaction> GetTransactions(string _connectionString, string _transaction)
        {
            var res = _dapperRepository.ExecuteAsStoredProc<Transaction>(_connectionString, _transaction);
            return res;
        }

        public IList<Transaction> GetTransactionsByDate(string _connectionString, string _transaction, TransactionRequest request)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@startDate", SqlDbType.DateTime){Value = request.StartDate},
                new SqlParameter("@endDate", SqlDbType.DateTime) { Value = request.EndDate }
            };

            var res = _dapperRepository.ExecuteStoredProc<Transaction>(_connectionString, _transaction, sqlParameters);
            return res;
        }

        public void SaveTransactions(string _connectionString, string _transaction, TransactionRequest request)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>() {
                new SqlParameter("@amount", SqlDbType.Decimal){Value = request.Amount },
                new SqlParameter("@accountType", SqlDbType.Int){Value = request.AcounTypetId },
                new SqlParameter("@transactionType", SqlDbType.Int){Value = request.TransactionTypeId },
                new SqlParameter("@expenseId", SqlDbType.Int){Value = request.ExpenseId },
                new SqlParameter("@description", SqlDbType.VarChar){Value = request.Description }
                };
            _dapperRepository.ExecuteStoredProc(_connectionString, _transaction, sqlParameters);
        }

        public IList<Expense> GetExpenses(string connectionString, string _transaction)
        {
            var res = _dapperRepository.ExecuteAsStoredProc<Expense>(connectionString, _transaction);
            return res;
        }

        public IList<Account> GetAccounts(string connectionString, string _transaction)
        {
            var res = _dapperRepository.ExecuteAsStoredProc<Account>(connectionString, _transaction);
            return res;
        }

        public void SaveAccount(string _connectionString, string _transaction, AccountRequest request)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>() {
                new SqlParameter("@accountType", SqlDbType.VarChar){Value = request.AccountType },
                };
            _dapperRepository.ExecuteStoredProc(_connectionString, _transaction, sqlParameters);

        }
    }
}


