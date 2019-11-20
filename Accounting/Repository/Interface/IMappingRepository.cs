using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Repository.Interface
{
    public interface IMappingRepository
    {
        IList<Mapping> GetMappingRequest();
        void SaveMapping(SaveMappingRequest request);
        void DeleteMapping(DeleteMappingRequest request);
    }
}
