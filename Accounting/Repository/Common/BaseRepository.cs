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

        public IList<Transaction> GetTransactionsByDate(string _connectionString, string _transaction, TransactionByDateRequest request)
        {
            var res = _dapperRepository.ExecuteStoredProc<Transaction>(_connectionString, _transaction, request);
            return res;
        }

        public void SaveTransactions(string _connectionString, string _transaction, TransactionRequest request)
        {
            _dapperRepository.ExecuteStoredProc(_connectionString, _transaction, request);
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
            _dapperRepository.ExecuteStoredProc(_connectionString, _transaction, request);

        }
    }
}


