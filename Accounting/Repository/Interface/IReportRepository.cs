using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IReportRepository
    {
        IList<ProssedImportFiles> GetImportFileRequest();

        void SaveImportFileRequest(SaveImportFileRequest request);

        void CompleteImportFileRequest(object request);

        void RollbackImportRequest(RollbackImportFileRequest request);
       
    }
}
