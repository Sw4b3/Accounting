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

        public IList<Transaction> GetTransactionsRequest()
        {
            return GetTransactions(DatabaseConnection.connection, _connection,_transaction);
        }

        public IList<Transaction> GetTransactionsByDateRequest(TransactionByDateRequest request)
        {
            return GetTransactionsByDate(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public void SaveTransactionsRequest(TransactionRequest request)
        {
            SaveTransactions(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public void UpdateTransactionsRequest(TransactionUpdateRequest request)
        {
            UpdateTransactions(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public IList<TransactionAnalysis> GetTransactionAnalysisRequest()
        {
            return GetTransactionAnalysis(DatabaseConnection.connection, _connection, _transaction);
        }
    }
}
