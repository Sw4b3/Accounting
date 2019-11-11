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
    public class MappingService : IMappingService
    {
        private readonly UnitOfWork uow;

        public MappingService()
        {
            uow = new UnitOfWork();
        }

        public IList<Mapping> GetMappings()
        {
            try
            {
                uow.CreateUnitOfWork();
                var res = uow.MappingRepository.GetMappingRequest();
                uow.Commit();
                return res;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void SaveMapping(SaveMappingRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.MappingRepository.SaveMapping(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public void DeleteMapping(DeleteMappingRequest request)
        {
            try
            {
                uow.CreateUnitOfWork();
                uow.MappingRepository.DeleteMapping(request);
                uow.Commit();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
