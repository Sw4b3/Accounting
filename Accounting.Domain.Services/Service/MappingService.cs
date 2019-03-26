using Accounting.Domain.Services.Service.Interface;
using Accounting.Models.Models;
using Accounting.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service
{
    class MappingService: IMappingService
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
    }
}
