using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Repository.Interface
{
    public interface IReportRepository
    {
        IList<ProssedImportFiles> GetImportFileRequest();

        void SaveImportFileRequest(SaveImportFileRequest request);

        void CompleteImportFileRequest(object request);

        void RollbackImportRequest(ImportFileRequest request);

        void DeleteImportRequest(ImportFileRequest request);
    }
}
