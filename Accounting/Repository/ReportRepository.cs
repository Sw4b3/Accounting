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
    public class ReportRepository : BaseRepository, IReportRepository
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        public ReportRepository(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
        }
        public IList<ProssedImportFiles> GetImportFileRequest()
        {
            var res = Get<ProssedImportFiles>(DatabaseConnection.connection, SQLStoredProcedures.getImportFile, _connection, _transaction);
            return res;
        }

        public void SaveImportFileRequest(SaveImportFileRequest request)
        {
            Save(DatabaseConnection.connection, SQLStoredProcedures.saveImportFile, request, _connection, _transaction);
        }

        public void CompleteImportFileRequest(object request)
        {
            DapperRepository.ExecuteStoredProc(DatabaseConnection.connection, SQLStoredProcedures.completeImportFile, request, _connection, _transaction);
        }

        public void RevertImportRequest(RevertImportFileRequest request)
        {
            DapperRepository.ExecuteStoredProc(DatabaseConnection.connection, SQLStoredProcedures.revertImportFile, request, _connection, _transaction);
        }
  
    }
}
