using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository
{
    public class TransactionRepository : BaseRepository, ITransactionRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public TransactionRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Transaction> GetTransactionsByDateRequest(DateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(DatabaseConnection.connection, SQLStoredProcedures.getGetTransactionByDate, request, _connection, _transaction);
            return res;
        }

        public IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(DatabaseConnection.connection, SQLStoredProcedures.searchTransactionByDate, request, _connection, _transaction);
            return res;
        }

        public void SaveTransactionRequest(SaveTransactionRequest request)
        {
            Save<SaveTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.saveTransaction, request, _connection, _transaction);
        }

        public void SaveTransactionStagingRequest(SaveTransactionRequest request)
        {
            Save<SaveTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.saveTransactionStaging, request, _connection, _transaction);
        }

        public void UpdateTransactionRequest(UpdateTransactionRequest request)
        {
            Update<UpdateTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.updateTransaction, request, _connection, _transaction);
        }

        public void DeleteTransactionStagingRequest(DeleteTransactionRequest request)
        {
            Delete<DeleteTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.deleteTransaction, request, _connection, _transaction);
        }
    }
}
