using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository.Common;
using Accounting.Repository.Interface;
using System.Collections.Generic;
using System.Data;

namespace Accounting.Repository
{
    public class ReportRepository : BaseRepository, IReportRepository
    {
        private readonly IDbConnection _connection;
        private readonly IDbTransaction _transaction;

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
            Update(DatabaseConnection.connection, SQLStoredProcedures.completeImportFile, request, _connection, _transaction);
        }

        public void RollbackImportRequest(ImportFileRequest request)
        {
            Update(DatabaseConnection.connection, SQLStoredProcedures.rollbackImportFile, request, _connection, _transaction);
        }

        public void DeleteImportRequest(ImportFileRequest request)
        {
            Delete(DatabaseConnection.connection, SQLStoredProcedures.deleteImportFile, request, _connection, _transaction);
        }

    }
}
