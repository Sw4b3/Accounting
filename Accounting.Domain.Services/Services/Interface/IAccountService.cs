using Accounting.Models.Models;
using Accounting.Models.Requests;
using System.Collections.Generic;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IAccountService
    {
        IList<Account> GetAccounts();

        Account GetAccount(GetAccountRequest accountNo);

        void SaveAccount(SaveAccountRequest account);

        void UpdateAccount(UpdateAccountRequest request);
    }
}
