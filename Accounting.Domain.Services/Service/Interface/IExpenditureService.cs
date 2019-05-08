using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IExpenditureService
    {
        IList<Expenditure> GetExpenditureByDateRequest();

        IList<ExpenditureType> GetExpenditureTypes();

        IList<ExpenditureOverview> GetExpenditureOverview();

        void SaveExpenditureTypes(SaveExpenditureTypeRequest request);

        void Update();

        void Delete();
        
    }
}
