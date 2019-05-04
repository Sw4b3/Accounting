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

namespace Accounting
{
    public class AnalyticsRepository: IAnalyticsRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public AnalyticsRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }

        public IList<Statistic> GetAnalyticsStatistics(GetDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Statistic>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsStatistics, request, _connection, _transaction);
            return res;
        }

        public IList<AnalyticsOverview> GetAnalyticOverviewRequest(GetDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<AnalyticsOverview>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsOverview, request, _connection, _transaction);
            return res;
        }


        public IList<AnalysisByDay> GetAnalyticsByDayRequest(GetDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<AnalysisByDay>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsByDay, request, _connection, _transaction);
            return res;
        }

        public IList<AnalysisByMonth> GetAnalyticsByMonthRequest()
        {
            var res = DapperRepository.ExecuteAsStoredProc<AnalysisByMonth>(DatabaseConnection.connection, SQLStoredProcedures.getAnalyticsByMonth, _connection, _transaction);
            return res;
        }
    }
}
