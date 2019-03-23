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

        public IList<Transaction> GetTransactionsByDateRequest(GetTransactionByDateRequest request)
        {
            return GetTransactionsByDate(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request)
        {
            return SearchTransactionsByDate(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public void SaveTransactionsRequest(GetTransactionRequest request)
        {
            SaveTransactions(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public void UpdateTransactionsRequest(UpdateTransactionRequest request)
        {
            UpdateTransactions(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public IList<TransactionAnalyticsOverview> GetAnalyticOverviewRequest(GetTransactionByDateRequest request)
        {
            return GetAnalyticsOverview(DatabaseConnection.connection, request, _connection, _transaction);
        }


        public IList<TransactionAnalyticsByDay> GetAnalyticsByDayRequest(GetTransactionByDateRequest request)
        {
            return GetAnalyticsByDay(DatabaseConnection.connection, request, _connection, _transaction);
        }

        public IList<TransactionAnalyticsByMonth> GetAnalyticsByMonthRequest()
        {
            return GetAnalyticsByMonth(DatabaseConnection.connection, _connection, _transaction);
        }
    }
}
