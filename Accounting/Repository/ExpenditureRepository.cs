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
    public class ExpenditureRepository : IExpenditureRepository
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

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
