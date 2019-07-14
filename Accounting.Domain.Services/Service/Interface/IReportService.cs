using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IReportService
    {
        IList<ProssedImportFiles> GetImportFile();

        void SaveImportFile(SaveImportFileRequest request);

        void RollbackImport(RollbackImportFileRequest request);

        void CompleteImport(RollbackImportFileRequest rollbackImportFileRequest);
    }
}
