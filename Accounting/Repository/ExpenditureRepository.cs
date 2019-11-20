using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace Accounting.Repository
{
    public class ExpenditureRepository : BaseRepository, IExpenditureRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

        public ExpenditureRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }


        public IList<Expenditure> GetExpenditureByDateRequest(DateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Expenditure>(DatabaseConnection.connection, SQLStoredProcedures.getExpendituresByDate, request, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureType> GetExpenditureTypes()
        {
            var res = Get<ExpenditureType>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureTypes, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureRule> GetExpenditureRules()
        {
            var res = Get<ExpenditureRule>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureRules, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureOverview> GetExpenditureOverview(DateRequest request)
        {
            var res = GetWithParamater<ExpenditureOverview>(DatabaseConnection.connection, SQLStoredProcedures.getExpendituresOverview, request, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureOverview> GetExpenditureRuleOverview(DateRequest request)
        {
            var res = GetWithParamater<ExpenditureOverview>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureRuleOverview, request, _connection, _transaction);
            return res;
        }

        public void ImportExpenditure(DateRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveExpenditure, request, _connection, _transaction);
        }

        public void SaveExpenditureRule(SaveExpenditureTypeRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveExpendituresRule, request, _connection, _transaction);
        }

        public void UpdateExpenditure(UpdateExpenditureRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.updateExpenditure, request, _connection, _transaction);
        }

        public void UpdateExpenditureRule(UpdateExpenditureRuleRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.updateExpendituresRules, request, _connection, _transaction);
        }

        public void DeleteExpenditureRule(DeleteExpenditureRuleRequest request)
        {
            Delete(DatabaseConnection.connection, SQLStoredProcedures.deleteExpendituresRules, request, _connection, _transaction);
        }

        public void AutoResolveMappings(DateRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.autoResolveMappings, request, _connection, _transaction);
        }
    }
}
