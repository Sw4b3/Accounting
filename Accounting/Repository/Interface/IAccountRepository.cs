using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Repository.Interface
{
    public interface IAccountRepository
    {
        IList<Account> GetAccountRequest();

        Account GetAccountRequest(GetAccountRequest AccountNo);

        void SaveAccountRequest(SaveAccountRequest request);

        void UpdateAccountRequest(UpdateAccountRequest request);
    }
}
