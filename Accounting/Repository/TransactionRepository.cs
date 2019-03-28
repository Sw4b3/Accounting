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
            var res = DapperRepository.ExecuteStoredProc<Transaction>(DatabaseConnection.connection, SQLStoredProcedures.getGetTransactionByDate, request, _connection, _transaction);
            return res;
        }

        public IList<Transaction> SearchTransactionsByDateRequest(SearchTransactionByDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Transaction>(DatabaseConnection.connection, SQLStoredProcedures.searchTransactionByDate, request, _connection, _transaction);
            return res;
        }

        public void SaveTransactionsRequest(GetTransactionRequest request)
        {
            Save<GetTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.saveTransaction, request, _connection, _transaction);
        }

        public void UpdateTransactionsRequest(UpdateTransactionRequest request)
        {
            Update<UpdateTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.updateTransaction, request, _connection, _transaction);
        }

        public void DeleteTransactionsRequest(DeleteTransactionRequest request)
        {
            Delete<DeleteTransactionRequest>(DatabaseConnection.connection, SQLStoredProcedures.deleteTransaction, request, _connection, _transaction);
        }

        public IList<AnalyticsOverview> GetAnalyticOverviewRequest(GetTransactionByDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<AnalyticsOverview>(DatabaseConnection.connection, SQLStoredProcedures.spGetAnalyticsOverview, request, _connection, _transaction);
            return res;
        }


        public IList<AnalysisByDay> GetAnalyticsByDayRequest(GetTransactionByDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<AnalysisByDay>(DatabaseConnection.connection, SQLStoredProcedures.spGetAnalyticsByDay, request, _connection, _transaction);
            return res;
        }

        public IList<AnalysisByMonth> GetAnalyticsByMonthRequest()
        {
            var res = DapperRepository.ExecuteAsStoredProc<AnalysisByMonth>(DatabaseConnection.connection, SQLStoredProcedures.spGetAnalyticsByMonth, _connection, _transaction);
            return res;
        }
    }
}
