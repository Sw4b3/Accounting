using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using System;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service
{
    public class ReportService : IReportService
    {
        private readonly UnitOfWork uow;

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

        public void CompleteImport(ImportFileRequest request)
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

        public void RollbackImport(ImportFileRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ReportRepository.RollbackImportRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void DeleteImport(ImportFileRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ReportRepository.DeleteImportRequest(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
