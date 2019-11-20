using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IReportService
    {
        IList<ProssedImportFiles> GetImportFile();

        void SaveImportFile(SaveImportFileRequest request);

        void RollbackImport(ImportFileRequest request);

        void CompleteImport(ImportFileRequest rollbackImportFileRequest);

        void DeleteImport(ImportFileRequest importFileRequest);
    }
}
