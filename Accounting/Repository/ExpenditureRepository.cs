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
    public class ExpenditureRepository : BaseRepository, IExpenditureRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public ExpenditureRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }


        public IList<Expenditure> GetExpenditureByDateRequest(GetDateRequest request)
        {
            var res = DapperRepository.ExecuteStoredProc<Expenditure>(DatabaseConnection.connection, SQLStoredProcedures.getExpendituresByDate, request, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureType> GetExpenditureTypes()
        {
            var res = DapperRepository.ExecuteStoredProc<ExpenditureType>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureTypes, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureType> GetExpenditureRules()
        {
            var res = DapperRepository.ExecuteStoredProc<ExpenditureType>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureRules, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureOverview> GetExpenditureOverview()
        {
            var res = DapperRepository.ExecuteStoredProc<ExpenditureOverview>(DatabaseConnection.connection, SQLStoredProcedures.getExpendituresOverview, _connection, _transaction);
            return res;
        }

        public IList<ExpenditureOverview> GetExpenditureRuleOverview()
        {
            var res = DapperRepository.ExecuteStoredProc<ExpenditureOverview>(DatabaseConnection.connection, SQLStoredProcedures.getExpenditureRuleOverview, _connection, _transaction);
            return res;
        }

        public void ImportExpenditure(GetDateRequest request)
        {
            DapperRepository.ExecuteStoredProc(DatabaseConnection.connection, SQLStoredProcedures.saveExpenditure, request, _connection, _transaction);
        }

        public void SaveExpenditureRule(SaveExpenditureTypeRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveExpendituresRule, request, _connection, _transaction);
        }

        public void UpdateExpenditure(UpdateExpenditureRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.updateExpenditure, request, _connection, _transaction);
        }

        public void UpdateExpenditureType(UpdateExpenditureTypeRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.updateExpendituresTypes, request, _connection, _transaction);
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
