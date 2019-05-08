using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Models.Requests;
using Accounting.Repository;
using Accounting.Domain.Services.Utillies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service
{
    public class ExpenditureService : IExpenditureService
    {
        private UnitOfWork uow;

        public ExpenditureService()
        {
            uow = new UnitOfWork();
        }

        public IList<Expenditure> GetExpenditureByDateRequest()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.ExpenditureRepository.GetExpenditureByDateRequest(Extensions.GetCurrentMonth());
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Save()
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.Save();
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void Update()
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.Update();
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void Delete()
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.ExpenditureRepository.Delete();
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

    }
}
