using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service
{
    public class ReportService : IReportService
    {
        private UnitOfWork uow;

        public ReportService()
        {
            uow = new UnitOfWork();
        }

        public IList<ProssedImportFiles> GetImportFile()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ReportRepository.GetImportFileRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveImportFile(SaveImportFileRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ReportRepository.SaveImportFileRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void CompleteImport(RevertImportFileRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ReportRepository.CompleteImportFileRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void RevertImport(RevertImportFileRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ReportRepository.RevertImportRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
