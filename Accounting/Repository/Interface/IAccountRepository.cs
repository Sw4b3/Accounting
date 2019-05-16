using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Repository.Interface
{
    public interface IAccountRepository
    {
        IList<Account> GetAccountRequest();

        void SaveAccountRequest(SaveAccountRequest request);

        void UpdateAccountRequest(UpdateAccountRequest request);
    }
}
