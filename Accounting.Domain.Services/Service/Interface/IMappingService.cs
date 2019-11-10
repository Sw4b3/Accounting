using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IMappingService
    {
        IList<Mapping> GetMappings();
        void SaveMapping(SaveMappingRequest request);
    }
}
