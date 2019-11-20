using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace Accounting
{
    public class AnalyticsRepository : BaseRepository, IAnalyticsRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public AnalyticsRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Statistic> GetAnalyticsStatistics(DateRequest request)
        {
            var res = GetWithParamater<Statistic>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsStatistics, request, _connection, _transaction);
            return res;
        }

        public IList<AnalyticsOverview> GetAnalyticOverviewRequest(DateRequest request)
        {
            var res = GetWithParamater<AnalyticsOverview>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsOverview, request, _connection, _transaction);
            return res;
        }


        public IList<AnalysisByDay> GetAnalyticsByDayRequest(DateRequest request)
        {
            var res = GetWithParamater<AnalysisByDay>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsByDay, request, _connection, _transaction);
            return res;
        }

        public IList<AnalysisByMonth> GetAnalyticsByMonthRequest()
        {
            var res = Get<AnalysisByMonth>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsByMonth, _connection, _transaction);
            return res;
        }

        public IList<AnalysisBySavings> GetAnalyticsSavings()
        {
            var res = Get<AnalysisBySavings>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsSavings, _connection, _transaction);
            return res;
        }
    }
}
