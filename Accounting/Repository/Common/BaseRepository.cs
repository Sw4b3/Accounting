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

        public IList<Transaction> GetTransactionsByDate(string _connectionString, GetTransactionByDateRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(_connectionString, SQLStoredProcedures.getGetTransactionByDate, request, connection, transaction);
            return res;
        }

        public IList<Transaction> SearchTransactionsByDate(string _connectionString, SearchTransactionByDateRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(_connectionString, SQLStoredProcedures.searchTransactionByDate, request, connection, transaction);
            return res;
        }

        public void SaveTransactions(string _connectionString, GetTransactionRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, SQLStoredProcedures.saveTransaction, request, connection, transaction);
        }

        public void UpdateTransactions(string _connectionString, UpdateTransactionRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, SQLStoredProcedures.updateTransaction, request, connection, transaction);
        }

        public IList<TransactionAnalysis> GetTransactionAnalysis(string _connectionString, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<TransactionAnalysis>(_connectionString, SQLStoredProcedures.getTransactionAnalysis, connection, transaction);
            return res;
        }

        public IList<TransactionAnalysisByDay> GetTransactionAnalysisByDay(string _connectionString, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<TransactionAnalysisByDay>(_connectionString, SQLStoredProcedures.getTransactionAnalysisByDay, connection, transaction);
            return res;
        }

        public IList<Expense> GetExpenses(string connectionString, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<Expense>(connectionString, SQLStoredProcedures.getGetExpenses, connection, transaction);
            return res;
        }

        public IList<Account> GetAccounts(string connectionString, IDbConnection connection, IDbTransaction transaction)
        {
            var res = DapperRepository.ExecuteAsStoredProc<Account>(connectionString, SQLStoredProcedures.getGetAccounts, connection, transaction);
            return res;
        }

        public void SaveAccount(string _connectionString, GetAccountRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, SQLStoredProcedures.saveAccount, request, connection, transaction);
        }
    }
}


