using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Accounting.Repository.Interface
{
    public interface IExpenditureRepository 
    {
        IList<Expenditure> GetExpenditureByDateRequest(GetDateRequest request);

        void Save();

        void Update();

        void Delete();
    }
}
