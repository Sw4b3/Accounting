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
    public class BaseRepository : IBaseRepository
    {
   
        public IList<Transaction> GetTransactions(string _connectionString, string _transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<Transaction>(_connectionString, _transaction);
            return res;
        }

        public IList<Transaction> GetTransactionsByDate(string _connectionString, string _transaction, TransactionByDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(_connectionString, _transaction, request);
            return res;
        }

        public void SaveTransactions(string _connectionString, string _transaction, TransactionRequest request)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, _transaction, request);
        }

        public void UpdateTransactions(string _connectionString, string _transaction, TransactionUpdateRequest request)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, _transaction, request);
        }

        public IList<TransactionAnalysis> GetTransactionAnalysis(string _connectionString, string _transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<TransactionAnalysis>(_connectionString, _transaction);
            return res;
        }

        public IList<Expense> GetExpenses(string connectionString, string _transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<Expense>(connectionString, _transaction);
            return res;
        }

        public IList<Account> GetAccounts(string connectionString, string _transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<Account>(connectionString, _transaction);
            return res;
        }

        public void SaveAccount(string _connectionString, string _transaction, AccountRequest request)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, _transaction, request);

        }
    }
}


