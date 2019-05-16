using Accounting.Models.Models;
using Accounting.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Services.Service.Interface
{
    public interface IAccountService
    {
        IList<Account> GetAccount();

        void SaveAccount(SaveAccountRequest account);

        void UpdateAccount(UpdateAccountRequest request);
    }
}
