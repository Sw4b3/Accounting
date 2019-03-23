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

  
        public void SaveTransactions(string _connectionString, GetTransactionRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, SQLStoredProcedures.saveTransaction, request, connection, transaction);
        }

        public void UpdateTransactions(string _connectionString, UpdateTransactionRequest request, IDbConnection connection, IDbTransaction transaction)
        {
            DapperRepository.ExecuteStoredProc(_connectionString, SQLStoredProcedures.updateTransaction, request, connection, transaction);
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


