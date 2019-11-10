using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
   public interface IMappingRepository
    {
        IList<Mapping> GetMappingRequest();
        void SaveMapping(SaveMappingRequest request);
    }
}
